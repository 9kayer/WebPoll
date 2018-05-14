using System;
using System.Collections.Generic;
using System.Text;
using WebPoll.Model.Models;

namespace WebPoll.Repository.Exceptions
{
    public class ElementInsertException<T> : RepositoryException where T : IModel
    {
        
        public ElementInsertException(T model, string message) : base("Model: " + model.ToString() + ", message: " + message)
        {
        }

        public ElementInsertException(T model, string message, Exception ex) : base("Model: " + model.ToString() + ", message: " + message, ex)
        {
        }
    }
}
