namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class Tamplates
{
     public static string GetTampleteDocumentation(){
          StringBuilder Estrutura = new StringBuilder();
          Estrutura.AppendLine("<!DOCTYPE html>");
          Estrutura.AppendLine("<html>");
          Estrutura.AppendLine("   <head>");
          Estrutura.AppendLine("        <link rel=\"stylesheet\" type=\"text/css\" href=\"/home/reginaldo/Desenvolvimento/DocWriter/DocWrite/style.css\">");
          Estrutura.AppendLine("        <title> {title} </title>");
          Estrutura.AppendLine(    "</head>");
          Estrutura.AppendLine("   <body>");
          Estrutura.AppendLine("   <div class=\"container\">");
          Estrutura.AppendLine("        {body}");
          Estrutura.AppendLine("   <div>");
          Estrutura.AppendLine("   </body>");
          Estrutura.AppendLine("</html>");
          return Estrutura.ToString();
        
     }
}