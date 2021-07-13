using System;
using System.Collections.Generic;
using PetShoppe.Data;
using PetShoppe.Models;

namespace PetShoppe.Services
{
    public class CatsService
    {
        public List<Cat> GetAll()
        {
            return FakeDb.Cats;
        }

        public Cat GetCatById(int id)
        {
            return FakeDb.Cats.Find(c => c.Id == id);
        }

        public Cat createCat(Cat catData)
        {
            var r = new Random();
            catData.Id = r.Next(1000, 999999);
            FakeDb.Cats.Add(catData);
            return catData;
        }

        public Cat removeCat(int id)
        {
            var cat = FakeDb.Cats.Find(c => c.Id == id);
            if (cat == null)
            {
                throw new Exception("Invalid Id");
            }

            // if (creatorId != cat.CreatorId)
            // {
            //     throw new Exception("Unathorized to do that");
            // }
            FakeDb.Cats.Remove(cat);
            return cat;

        }
    }
}