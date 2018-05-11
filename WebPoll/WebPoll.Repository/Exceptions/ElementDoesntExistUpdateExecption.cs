using System;
using WebPoll.Model.Models;

namespace WebPoll.Repository.Exceptions
{
    public class ElementDoesntExistUpdateExecption<T> : RepositoryException where T : IModel
    {
        
        public ElementDoesntExistUpdateExecption(T model, string message) : base("Model: " + model.ToString() + ", message: " + message)
        {
        }
        public ElementDoesntExistUpdateExecption(T model, string message, Exception ex) : base("Model: " + model.ToString() + ", message: " + message, ex)
        {
        }
    }
}
