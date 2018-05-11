using System;
using WebPoll.Model.Models;

namespace WebPoll.Repository.Exceptions
{
    public class ElementDoesntExistDeleteExecption<T> : RepositoryException where T : IModel
    {
        
        public ElementDoesntExistDeleteExecption(int id, string message) : base("Id: " + id + ", message: " + message)
        {
        }

        public ElementDoesntExistDeleteExecption(int id, string message, Exception ex) : base("Id: " + id + ", message: " + message, ex)
        {
        }
    }
}
