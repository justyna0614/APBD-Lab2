using System;
using System.Collections.Generic;

namespace LegacyApp
{
    public class UserService
    {
        private readonly List<IUserLimitProcessor> _processors;

        public UserService()
        {
            _processors = new List<IUserLimitProcessor>
            {
                new NormalClientUserLimitProcessor(),
                new ImportantClientUserLimitProcessor(),
                new VeryImportantClientUserLimitProcessor()
            };
        }
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!UserValidation.IsNameValid(firstName, lastName)
                || !UserValidation.IsEmailValid(email)
                || !UserValidation.IsValidAge(dateOfBirth)
               )
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            
            ProcessUser(user);

            if (user.HasValidLimit())
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private void ProcessUser(User user)
        {
            var processor = _processors.Find(p => p.ClientType == user.Client.Type);
            processor.Process(user);
        }
    }
}