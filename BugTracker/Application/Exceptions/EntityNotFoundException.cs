using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private int _id;
        private string _tableName;

        public EntityNotFoundException(int id, string tableName)
        {
            _id = id;
            _tableName = tableName;
        }

        public override string Message => $"Entity with id = '{_id}' doesn't exist in table = '{_tableName}'";
    }
}
