using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts
{
    internal interface IServices
    {
       
       List<contacsRep> selectAll();
       List<contacsRep> selectById(int id);
       bool insert(string Name,string Family,string Mobile,string Email,string Address);
       bool remove(int id);
       bool edit(int id,string Name,string Family,string Mobile,string Email, string Address);
       List<contacsRep> search(string key);
    
    }
}
