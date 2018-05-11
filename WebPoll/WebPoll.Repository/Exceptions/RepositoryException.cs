using System;
using System.Collections.Generic;
using System.Text;
using WebPoll.Model.Models;

namespace WebPoll.Repository.Exceptions
{
    public abstract class RepositoryException : Exception
    {
        public RepositoryException() : base()
        {
        }

        public RepositoryException(string message) : base(message)
        {
        }

        public RepositoryException(string message, Exception ex) : base(message, ex)
        {
        }

    }
}
