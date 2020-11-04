using MediatR;
using ModelArchive.Application.Models;

namespace ModelArchive.Application.Modules.Authentication.Commands.SetUserLanguage
{
    public class SetUserLanguageCommand : IRequest<Response<Unit>>
    {
        public string Language { get; set; }
    }
}
