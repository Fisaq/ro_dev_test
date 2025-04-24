using System.Net;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace RO.DevTest.Domain.Exception;

/// <summary>
/// Returns a <see cref="HttpStatusCode.BadRequest"/> to
/// the request
/// </summary>
public class BadRequestException : ApiException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public BadRequestException(IdentityResult result) : base(result)
    {
        //Create a new list of errors
        Errors = new List<string>();

        foreach (var error in result.Errors)
        {
            //Add the error to the list
            Errors.Add(error.Description);
        }
    }
    public BadRequestException(string error) : base(error)
    {
        Errors = new List<string> { error };
    }
    public BadRequestException(ValidationResult validationResult) : base(validationResult)
    {
        Errors = new List<string>();
        foreach (var error in validationResult.Errors)
        {
            //Add the validation error to the list
            Errors.Add(error.ErrorMessage);
        }
    }

    public new List<string> Errors { get; }

    //This object returns a custom error message
    public object GetErrors()
    {
        return new
        {
            StatusCode = (int)StatusCode,
            Message = "Bad Request Error",
            Errors,
        };
    }
}
