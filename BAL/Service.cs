using System;

namespace BAL
{
    public class Service:IService
    {

        private readonly IDataAccess _dal;

        public Service(IDataAccess dal)
        {
            _dal = dal; 
        }
        public string GetAll()
        {
            return _dal.GetAll();
        }
    }
}
