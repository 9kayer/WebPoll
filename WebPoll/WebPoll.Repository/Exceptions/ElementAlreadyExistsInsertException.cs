using System;
using System.Collections.Generic;
using System.Text;
using WebPoll.Model.Models;

namespace WebPoll.Repository.Exceptions
{
    public class ElementAlreadyExistsInsertException<T> : RepositoryException where T : IModel
    {
        
        public ElementAlreadyExistsInsertException(T model, string message) : base("Model: " + model.ToString() + ", message: " + message)
        {
        }

        public ElementAlreadyExistsInsertException(T model, string message, Exception ex) : base("Model: " + model.ToString() + ", message: " + message, ex)
        {
        }
    }
}
