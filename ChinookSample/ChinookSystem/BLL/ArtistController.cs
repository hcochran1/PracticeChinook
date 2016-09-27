using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel; //ODS
using ChinookSystem.Data.Entities; //access to entity definitions
using ChinookSystem.Data.POCOs; //to access POCOs
using ChinookSystem.DAL; //to access context class
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class ArtistController
    {
        //dump the entire Artist entity
        //this will use Entity Framework access. Entity classes will be used to define the data
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Artist> Artist_ListAll()
        {
            //set up transaction area
            using (var context = new ChinookContext())
            {
                return context.Artists.ToList();
            }
        }

        //report a dataset containing data from multiple entities
        //this will use Linq to Entity access
        //POCO classes will be used to define the data
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbums> ArtistAlbums_Get()
        {
            //set up transaction area
            using (var context = new ChinookContext())
            {
                //need to set up linq query that will retrieve data
                //when you bring your query from LinqPad to your program, you must change the references to the data source
                //you may also need to change your navigation referencing used in LinqPad to the navigation properties you 
                //stated in the Entity class definitions
                var results = from x in context.Albums
                              where x.ReleaseYear == 2008
                              orderby x.Artists.Name, x.Title
                              select new ArtistAlbums
                              {
                                  //Name and Title are POCO class property names
                                  Name = x.Artists.Name,
                                  Title = x.Title
                              };
                //the following requires the query data in memory
                //.ToList()
                //At this point the query will actually execute
                return results.ToList();

            }
        }
    }
}
