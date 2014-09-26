using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Card_Game
{
    class XMLReader
    

    {

       static String[] symbols = { Codes.Symbols.C.ToString(), Codes.Symbols.D.ToString(), Codes.Symbols.H.ToString(), Codes.Symbols.S.ToString() };
       static  String[] vals = { Codes.Vals.TW.ToString(), Codes.Vals.TH.ToString(), Codes.Vals.FO.ToString(), Codes.Vals.FI.ToString(), 
                            Codes.Vals.SI.ToString(), Codes.Vals.SE.ToString(), Codes.Vals.EI.ToString(), Codes.Vals.NI.ToString(),
                            Codes.Vals.TE.ToString(), Codes.Vals.JA.ToString(), Codes.Vals.QU.ToString(), Codes.Vals.KI.ToString(),
                            Codes.Vals.AC.ToString() };

        public static int getWorth(Codes.Vals val)
        {
            int worth;
          
                XDocument doc = XDocument.Load(Codes.PATH);
                 worth = Convert.ToInt16(doc.Descendants(val.ToString()).Single().Value);
          
            
            return worth;
        }

        public static String getCardName(int no)
        {
            int sym = no % 4;
            int val = no / 4;
            return symbols[sym] + vals[val];
        }

        public static int getCardNO(String name)
        {
            XDocument doc = XDocument.Load(Codes.PATH);
            int no = Convert.ToInt16(doc.Descendants(name).Single().Value);
            return no;
        }

        public static void organizeCards()
        {
            XDocument xdoc = new XDocument();
            XElement demoNode = new XElement(Codes.PATH);

                for (int i = 0; i < vals.Length; i++)
                {
                     for (int j = 0; j < symbols.Length; j++)
                     {   
                        demoNode.Add(new XElement(symbols[j]+vals[i], i*symbols.Length+j));
                     }
                }

                demoNode.Add(new XElement(Codes.Vals.AC.ToString(), 00));
                demoNode.Add(new XElement(Codes.Vals.TW.ToString(), 01));
                demoNode.Add(new XElement(Codes.Vals.TH.ToString(), 02));
                demoNode.Add(new XElement(Codes.Vals.FO.ToString(), 03));
                demoNode.Add(new XElement(Codes.Vals.FI.ToString(), 04));
                demoNode.Add(new XElement(Codes.Vals.SI.ToString(), 05));
                demoNode.Add(new XElement(Codes.Vals.SE.ToString(), 06));
                demoNode.Add(new XElement(Codes.Vals.EI.ToString(), 07));
                demoNode.Add(new XElement(Codes.Vals.NI.ToString(), 08));
                demoNode.Add(new XElement(Codes.Vals.TE.ToString(), 09));
                demoNode.Add(new XElement(Codes.Vals.JA.ToString(), 10));
                demoNode.Add(new XElement(Codes.Vals.QU.ToString(), 11));
                demoNode.Add(new XElement(Codes.Vals.KI.ToString(), 12));

                xdoc.Add(demoNode);
                xdoc.Save(Codes.PATH);
        }

       
    }
}
