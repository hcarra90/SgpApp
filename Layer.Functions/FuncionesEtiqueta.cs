using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Functions
{
    public static class FuncionesEtiqueta
    {
        public static string GetFigurasEtiquetaPacking()
        {
            StringBuilder stringData = new StringBuilder();

            stringData.Append("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR2,2~SD15^JUS^LRN^CI0^XZ");
            stringData.Append("^XA");
            stringData.Append("^MMT");
            stringData.Append("^PW799");
            stringData.Append("^LL0559");
            stringData.Append("^LS0");
            stringData.Append("^FO0,448^GFA,01792,01792,00028,:Z64:");
            stringData.Append("eJxjYBgFIxP8xwH+MDAw4tLDNCo3KjcqN5By+PLtKCAZAABxCzIs:3DD7");
            stringData.Append("^FO192,448^GFA,03072,03072,00048,:Z64:");
            stringData.Append("eJxjYBgFo2AU0BCw/ycaHACp5yDeaIVR9aPqR9WPqh9VP3LVk1q/jIJRAAcAlSZaYw==:3618");
            stringData.Append("^FO576,480^GFA,02688,02688,00028,:Z64:");
            stringData.Append("eJxjYBgFo2Awg/r/2MEfoFwDDj1Mo3KjcqNyo3IjRA5fGTkKRsHgBQDhrUgl:CD20");
            stringData.Append("^FO320,480^GFA,01920,01920,00020,:Z64:");
            stringData.Append("eJxjYBgFwxnI/0cFD4BiCmhqBEbFRsVGxegqhi1fjoKRBwAqpyhR:26C1");
            stringData.Append("^FO576,352^GFA,03584,03584,00028,:Z64:");
            stringData.Append("eJzt1sEJACAMBMEI9l+xEG0gkm9g9jvc/yIktVpZdJ5Vo80YY4wxNtA+v0ejuymyM2A=:96EC");
            stringData.Append("^FO288,352^GFA,03584,03584,00028,:Z64:");
            stringData.Append("eJzt1jEKACAMBMEI/v/FglrZJX1kth2uvwhJr7GT1rVsNBljjDHGGlrxe/RtB8hhM2A=:E894");
            stringData.Append("^FO0,352^GFA,03584,03584,00028,:Z64:");
            stringData.Append("eJzt1rENACAMA8GIyZmcwAJBaSPdtyf3jpDUK4vOs11sFmOMMcbYQPv9Hk3uAurfWu8=:48B2");
            stringData.Append("^FO0,480^GFA,01920,01920,00020,:Z64:");
            stringData.Append("eJxjYBgFwwf8RwNAIUZ0NQ2jYqNio2KDUQxb/h0FwxoAAO0sN5A=:5FC1");
            stringData.Append("^FO0,256^GFA,04224,04224,00044,:Z64:");
            stringData.Append("eJzt1rENACAMA0GzGaOxOayQSDSgu/rl2gkA9+yqlVEenVqtVqvVaj9uO/8BHnYAx/heng==:9D86");
            stringData.Append("^FO0,224^GFA,02816,02816,00044,:Z64:");
            stringData.Append("eJxjYBgFQxPU/ycSANU2EGtow6jaUbWjakfVjqodVTuqdqipJaVNMApAAAA3c36v:AC90");
            stringData.Append("^FO0,160^GFA,09600,09600,00100,:Z64:");
            stringData.Append("eJzt2aERACAQA0EkXUPJSBzQRAy/18BOdFr7pRNuP2OGN3QGg8FgMBgMBoPBYDAYDAaDwWAwGAxGaWOEP68V3iBJklSvCxuZ5Mk=:0F5A");
            stringData.Append("^FO192,64^GFA,04992,04992,00052,:Z64:");
            stringData.Append("eJzt1yEOACAMBMGm/P/LQIKrISkKMesnpy9CkqTSWJ3mMdlaSIZhGIZhGIZhmKt5+SXftgEJpVyd:B8F4");
            stringData.Append("^FO640,64^GFA,01920,01920,00020,:Z64:");
            stringData.Append("eJxjYBgFo4BCwPgfDRxgYGBCV6QwKjYqNio2Kjb8xLCVf0QCAF8AKcE=:CE77");
            stringData.Append("^FO0,64^GFA,01920,01920,00020,:Z64:");
            stringData.Append("eJxjYBgFo4Be4D8aeMDAwIiuRmBUbFRsVGxUbGiLYSvrsAAAQCUlvw==:2554");
            stringData.Append("^FO416,64^GFA,00384,00384,00012,:Z64:");
            stringData.Append("eJxjYKAtYGdnf/7xQYGMDJDNxt/+/POHHxJ2QLa87BGGYsk7NeVAthRDC0OyZMcLZSBbnN39wHHZMzHsQDYTc/+DZsseDjaQOYxnCg/");
            stringData.Append("+7JHhA4kzHFBsuNnBwQESlzlS2CB7Bmw+E8e55GaLDg4DkLj88YOMH3/I1IPNYW5meGDAUU9jv5IDAHl7JsE=:E6A5");
            stringData.Append("^FO544,288^GFA,00384,00384,00012,:Z64:");
            stringData.Append("eJxjYKAxePDgzz8bPubmBgYFhoMf/vyrk2dmP8CQwPx4RwNfsnV/3wOGB8wOAg08yYayLAmMCUwPXvyQeLyzu+EBkwKDQ+");
            stringData.Append("EfgXTDRgageoYHln0W9obNjQeA5jhIsBhIGzIyMgDFH8/oM2De2Qw0P4HBUfJMQbogIxtY/McPBTt75v4HIPUJBQkybIz8D4Di2AD/D+xsOgAAVmUzwQ==:6E74");

            return stringData.ToString();
        }
    }
}
