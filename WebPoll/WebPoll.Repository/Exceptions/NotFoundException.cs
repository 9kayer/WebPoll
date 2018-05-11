using System;
using System.Collections.Generic;
using System.Text;
using WebPoll.Model.Models;

namespace WebPoll.Repository.Exceptions
{
    public class NotFoundException<T> : RepositoryException where T : IModel
    {
        
        public NotFoundException(string name, string message) : base("name: " + name + ", message: " + message)
        {
        }

        public NotFoundException(int id, string message) : base("Id" + id + ", message: " + message)
        {
        }

        public NotFoundException(string name, string message, Exception ex) : base("name: " + name + ", message: " + message, ex)
        {
        }

        public NotFoundException(int id, string message, Exception ex) : base("Id" + id + ", message: " + message, ex)
        {
        }
    }
}
