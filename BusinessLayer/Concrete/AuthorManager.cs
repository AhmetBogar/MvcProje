using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {
        Repository<Author> repoauthor=new Repository<Author>();

        //Tüm yazar listesi getirme
        public List<Author> GetAll()
        {
            return repoauthor.List();
        }


        //Yeni yazar ekleme işlemi
        public int AddAuthorBL(Author p)
        {
            //Parametreden gönderilen değerlerin geçerliliğinin kontrolü
            if (p.AuthorName == "" | p.AuthorShort == "" | p.AuthorTitle == "")
            {
                return -1;
            }
            return repoauthor.Insert(p);
        }
        //Yazarı id değerine göre güncelleme sayfasına taşıma
        public Author FindAuthor(int id)
        {
            return repoauthor.Find(x => x.AuthorID == id);
        }
        public int EditAuthor(Author p)
        {
            Author author=repoauthor.Find(x=>x.AuthorID == p.AuthorID);
            author.AuthorShort = p.AuthorAbout;
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            return repoauthor.Update(author);
        }
    }
}
