﻿using System;
using WebPoll.Model.Models;

namespace WebPoll.Repository.Exceptions
{
    public class ElementUpdateException<T> : RepositoryException where T : IModel
    {
        
        public ElementUpdateException(T model, string message) : base("Model: " + model.ToString() + ", message: " + message)
        {
        }
        public ElementUpdateException(T model, string message, Exception ex) : base("Model: " + model.ToString() + ", message: " + message, ex)
        {
        }
    }
}
