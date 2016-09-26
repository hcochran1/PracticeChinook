using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace ChinookSystem.Data.Entities
{
    //reference or point to the SQL table that this file maps
    [Table("Albums")]
    public class Album
    {
        //Key notations is optional in the SQL pkey ends in ID or Id  (but Don puts it in anyway), notations is required if default of entity is NOT identity, notations is required if pkey is compound
        //(use it all the time)

        //properties can be fully implemented or auto implemented
        //property names should use sql attribute name 
        //properties should be listed in the same order as sql table attributes for ease of maintenance 
        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistID { get; set; }
        public int ReleaseYear { get; set; }
        public string ReleaseLabel { get; set; }

        //navigation properties for use by LINQ
        //these properties will be of type virtual
        //there are two types of navigation properties
        //properties that point to "children" use ICollection<T>
        //properties that point to "parents" use ParentName as the datatype
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual Artist Artists { get; set; }
    }
}
