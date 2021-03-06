﻿using Account.API.Entities;

namespace Account.Model.Request
{
    public class PetPostFullRequest
    {
        public int UserId { get; set; }
        public string PetName { get; set; }
        public bool IsMail { get; set; }
        public string Breed { get; set; }
        public AnimalType AnimalType { get; set; }
        public string AboutMe { get; set; }
        public string ImageFileName { get; set; }
        public string ImageUri { get; set; }
    }
}