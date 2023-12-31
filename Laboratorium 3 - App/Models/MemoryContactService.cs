﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laboratorium_3___App.Models
{
    public class MemoryContactService : IContactService
    {
        private readonly Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();
        private int id = 1;
        public void Add(Contact contact)
        {
            contact.Created = _timeProvider.GetCurrentData();
            contact.Id = id++;
            _contacts.Add(contact.Id, contact);
        }

        public void RemoveById(int id)
        {
            _contacts.Remove(id);
        }

        public List<Contact> FindAll()
        {
            return _contacts.Values.ToList();
        }

        public Contact? FindById(int id)
        {
            return _contacts.ContainsKey(id) ? _contacts[id] : null;
        }

        public void Update(Contact item)
        {
            _contacts[item.Id] = item;
        }

        public List<OrganizationEntity> FindAllOrganizationsForVieModel()
        {
            throw new NotImplementedException();    
        }

        public PagingList<Contact> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }

        private IDateTimeProvider _timeProvider;

        public MemoryContactService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }
    }
}
