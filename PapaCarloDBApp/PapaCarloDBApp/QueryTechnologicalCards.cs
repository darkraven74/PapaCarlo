using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapaCarloDBApp
{
    public class QueryTechnologicalCards
    {
        public List<TechnologicalCard> querySelectTechCards()
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query1 = from c in db.TechnologicalCards
                                 select c;
                    // List<TechnologicalCard> table = new List<TechnologicalCard>();
                    /*foreach (var item in query1)
                    {
                        var query = from s in db.ProductTechCards
                                    where s.TechCardId == item.Id
                                    select s;
                        table.Add(new TechCardsTable(item, query.ToList()));
                    }*/

                    return query1.ToList();

                }
            }
            return null;
        }

        public List<ProductAmountTable> querySelectTechCardProducts(int techCardId)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from s in db.ProductTechCards
                                join p in db.Products on s.ProductId equals p.Id
                                where s.TechCardId == techCardId
                                select new { s, p };

                    List<ProductAmountTable> prodAmount = new List<ProductAmountTable>();

                    foreach (var item in query)
                    {
                        prodAmount.Add(new ProductAmountTable(item.s.TechCardId, item.p, item.s.Amount, item.s.Type));
                    }
                    return prodAmount;
                }
            }
            return null;
        }

        public List<TechnologicalCard> querySelectTechCardBySearch(string name)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from c in db.TechnologicalCards
                                where c.Title.Contains(name)
                                select c;                 
                    return query.ToList();
                }
            }
            return null;
        }

        public bool queryAddTechCard(TechnologicalCard c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        db.TechnologicalCards.Add(c);
                        db.SaveChanges();

                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public bool queryUpdateTechCard(TechnologicalCard c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        int IdCard = c.Id;
                        TechnologicalCard card = db.TechnologicalCards.Find(IdCard);

                        card.Date = c.Date;
                        card.Title = c.Title;

                        db.ProductTechCards.RemoveRange(card.ProductTechCards);
                        card.ProductTechCards = c.ProductTechCards;
                        db.SaveChanges();

                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public bool queryDeleteTechCard(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        TechnologicalCard card = db.TechnologicalCards.Find(Id);
                        List<ProductTechCard> lsp = card.ProductTechCards;
                        db.ProductTechCards.RemoveRange(lsp);
                        db.TechnologicalCards.Remove(card);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public TechCardsTable queryFindTechCardById(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    TechnologicalCard s = db.TechnologicalCards.Find(Id);
                    //List<ProductTechCard> lsp = db.ProductTechCards.Select(it => new ProductTechCard() { Id = it.Id, ProductId = it.ProductId, Amount = it.Amount, Type = it.Type }).Where(r => r.TechCardId == Id).ToList();
                    List<ProductTechCard> lsp = s.ProductTechCards;
                    TechCardsTable table = new TechCardsTable(s, lsp);
                    return table;
                }
            }
            return null;
        }
    }
}
