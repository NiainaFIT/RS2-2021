using eProdaja.Database;
using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eProdaja.Services
{
    public interface IKorisniciService
    {   IList<KorisniciDto> GetAll(KorisniciSearchObject search);
        KorisniciDto GetById(int id);
        KorisniciDto Insert(KorisniciInsertRequestDto korisnici);
        KorisniciDto Update(int id, KorisniciInsertRequestDto korisnici);
        //Task<KorisniciDto> Login(string username, string password);
    }
}
