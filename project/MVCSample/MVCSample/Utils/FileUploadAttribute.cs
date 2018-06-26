using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSample.Utils
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileUploadAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string dependencyName;
        private readonly bool sizeFromDependency;
        private long maxFileSize = 0;
        private IEnumerable<string> extensionNames;
     
        public FileUploadAttribute(string dependencyPropertyName, string extensionnames)
        {            
            dependencyName = !string.IsNullOrEmpty(dependencyPropertyName) ? dependencyPropertyName : null;
            sizeFromDependency = true;
            extensionNames = string.IsNullOrEmpty(extensionnames) ? null 
                : extensionnames.ToLower().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        }

        public FileUploadAttribute(int megabytessize, string extensionnames)
        {
            maxFileSize = megabytessize * 1024;
            extensionNames = string.IsNullOrEmpty(extensionnames) ? null 
                : extensionnames.ToLower().Split(new[]{","}, StringSplitOptions.RemoveEmptyEntries);
            sizeFromDependency = false;
        }



        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (sizeFromDependency && !string.IsNullOrEmpty(dependencyName))
            {
                var containerType = validationContext.ObjectInstance.GetType();
                var field = containerType.GetProperty(dependencyName);
                if (field != null)
                {
                    var dependentvalue = field.GetValue(validationContext.ObjectInstance, null);
                    int refvalue = 0;
                    if (dependencyName != null && dependentvalue != null && int.TryParse(dependentvalue.ToString(), out refvalue))
                        maxFileSize = refvalue * 1024;
                }
            }

            BuildErrorMessage();

            var files = value as IEnumerable<HttpPostedFileBase>;

            if (files != null && files.Count() > 0)
            {
                foreach (HttpPostedFileBase file in files)
                {
                    if (file != null)
                    {
                        if (maxFileSize > 0 && file.ContentLength > maxFileSize)
                            return new ValidationResult(ErrorMessageString);

                        if (extensionNames != null && extensionNames.Count() > 0
                            && !extensionNames.Any(e => file.FileName.ToLower().EndsWith(e)))
                            return new ValidationResult(ErrorMessageString);
                    }
                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ErrorMessage = ErrorMessageString,
                ValidationType = "fileupload",
            };

            rule.ValidationParameters.Add("maxfilesize", (maxFileSize > 0 ? (maxFileSize / 1024) : 0).ToString());
            rule.ValidationParameters.Add("validtypes", extensionNames != null ? string.Join(",", extensionNames) : "*");
            yield return rule;
        }

        private void BuildErrorMessage()
        {
            if (maxFileSize > 0 && (extensionNames != null && extensionNames.Count() > 0))
            {
                ErrorMessage = string.Format("File with size {0} MB and extension name(s) {1} is allowed.",
                    maxFileSize.ToString("N0"),
                    string.Join(",", extensionNames));
            }
            else if (maxFileSize < 1 && (extensionNames != null && extensionNames.Count() > 0))
            {
                ErrorMessage = string.Format("File with extension name(s) {0} is allowed.",
                    string.Join(",", extensionNames));
            }
            else if (maxFileSize > 0 && (extensionNames == null || extensionNames.Count() < 1))
            {
                ErrorMessage = string.Format("File with size {0} MB is allowed.",
                    maxFileSize.ToString("N0"));
            }
        }

    }
}