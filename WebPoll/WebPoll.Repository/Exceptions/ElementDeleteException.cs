﻿using System;
using WebPoll.Model.Models;

namespace WebPoll.Repository.Exceptions
{
    public class ElementDeleteException<T> : RepositoryException where T : IModel
    {
        
        public ElementDeleteException(int id, string message) : base("Id: " + id + ", message: " + message)
        {
        }

        public ElementDeleteException(int id, string message, Exception ex) : base("Id: " + id + ", message: " + message, ex)
        {
        }
    }
}
