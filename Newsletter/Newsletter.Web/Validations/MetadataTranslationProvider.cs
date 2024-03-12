// Source: https://github.com/dotnet/aspnetcore/issues/4848#issuecomment-718060602
// Inspired from https://blogs.msdn.microsoft.com/mvpawardprogram/2017/05/09/aspnetcore-mvc-error-message/
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace GeniusChuck.Newsletter.Web.Validations
{
    public class MetadataTranslationProvider(Type type) : IValidationMetadataProvider
    {
        private readonly ResourceManager _resourceManager = new(type);
        private readonly Type _resourceType = type;

        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            foreach (var attribute in context.ValidationMetadata.ValidatorMetadata)
            {
                if (attribute is ValidationAttribute tAttr)
                {
                    // search a ressource that corresponds to the attribute type name
                    if (tAttr.ErrorMessage == null && tAttr.ErrorMessageResourceName == null)
                    {
                        var name = tAttr.GetType().Name;
                        if (_resourceManager.GetString(name) != null)
                        {
                            tAttr.ErrorMessageResourceType = _resourceType;
                            tAttr.ErrorMessageResourceName = name;
                            tAttr.ErrorMessage = null;
                        }
                    }
                }
            }
        }
    }
}