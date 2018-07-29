using System;
using System.Web;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Web.UI.WebControls;
using System.Linq;
using Classes.Tables;
using System.Xml;

/// <summary>
/// Summary description for DbConnect
/// </summary>
public class DbConnect : System.Web.UI.Page
{
    private static string _AK = "gh47GF9fhcs8G7gG9e";

    private static string _CK = "GmT94gUeMluElNZchutBfr2F9";
    private static string _CS = "n2Jor9XyuPGLY3lYxBDVZ9RzL8YuN7yWQoOrZdLVIawLVdfyrz";
    private static string _T = "3018180704-9nfyDBkLDntPwbxaAv3unIJt5djunJRTWyD25Ub";
    private static string _TS = "1FC9LXM9REZMfP6yhP77Rse1ZsuZQ5B8P6KWdKn29ZMPm";

    //private static string _AT = "CAAF1OY4vMOcBAA7LZBZCEK3FXm8U9EDKQuv5zZAqReA5IZALMiw052FVm2z79ZBQQDHNBVsOQbXF57jMpLcC5GlnISFUdFZAHDfOLJXA1uX3RogIDrVDKDqVcZCArnweo8tYJxME4cBZAOtAADygZBzOUl8DX0O0H99NKVyP9iSZBazM72VkTEAGNxBcnm45j9Xqzce9039iB6r5ySsugUYNNC";
    //private static string _FB_AppId = "410365035753703";
    //private static string _FB_AppSecret = "0a71e2a05d6be0675d867fdff83b3a0b";

    public static string AdminKey { get { return _AK; } }

    public static string ConsumerKey { get { return _CK; } }
    public static string ConsumerSecret { get { return _CS; } }
    public static string Token { get { return _T; } }

    public static string PrepareXML(object clsXML)
    {
        //XmlSerializer xsSubmit = new XmlSerializer(typeof(clsXML));
        System.Xml.Serialization.XmlSerializer xsSubmit = new System.Xml.Serialization.XmlSerializer(clsXML.GetType());
        XmlDocument doc = new XmlDocument();
        StringWriter sww = new System.IO.StringWriter();
        XmlWriter writer = XmlWriter.Create(sww);
        xsSubmit.Serialize(writer, clsXML);
        return sww.ToString(); // Your xml
        //context.Response.Write(xml);
        //x.Serialize(Console.Out, clsXML);
    }

    public static string TokenSecret { get { return _TS; } }

    /// <summary>
    /// Default Constructor
    /// </summary>
    public DbConnect()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string CommaSeparatedValues(CheckBoxList item)
    {
        return String.Join(",", item.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value));
    }

    //public static string GetPhysicalPath { get { return System.Web.HttpContext.Current.Request.PhysicalApplicationPath; } }

    /// <summary>
    /// Get Physical Path of the Web-Site
    /// </summary>
    public static string GetPhysicalPath { get { return System.AppDomain.CurrentDomain.BaseDirectory; } }

    /// <summary>
    /// Get Main Site base URL
    /// </summary>
    public static string GetBaseURL
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["SitePath"].ToString();
        }
    }

    /// <summary>
    /// Get Tilte of Admin Side Web-Pages
    /// </summary>
    public static string GetAdminTitle
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["SiteTitleAdmin"].ToString();
        }
    }

    /// <summary>
    /// Get Current DateTime in Indian Time Zone
    /// </summary>
    /// <returns>DataType : DateTime</returns>
    public static DateTime GetCurrentDateTimeIndia()
    {
        string str = "India Standard Time";
        TimeZone zone = TimeZone.CurrentTimeZone;
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(str);
        return TimeZoneInfo.ConvertTimeFromUtc(zone.ToUniversalTime(System.DateTime.Now), tz);
    }

    /// <summary>
    /// Function for sending mails, Return Error Message : If any error arise
    /// </summary>
    /// <param name="MailFrom">Email Id of Sender</param>
    /// <param name="MailTo">Email Id of Receiver</param>
    /// <param name="MailSubject">Subject of Email</param>
    /// <param name="MailBody">Mail Body in HTML Format</param>
    /// <returns>DataType : string</returns>
    public static string SendMail(string MailFrom, string MailTo, string MailSubject, string MailBody)
    {
        try
        {
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress(MailFrom);
            Msg.To.Add(MailTo);
            Msg.Subject = MailSubject;
            Msg.Body = MailBody;
            Msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtpout.secureserver.net";
            smtp.Port = 25;// 587;// 281;//587;//21;
            smtp.Credentials = new System.Net.NetworkCredential("info@gangdhari.com", "9829880533");
            smtp.Send(Msg);
            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    /// <summary>
    /// Shortenth URL
    /// </summary>
    /// <param name="LongUrl">Pass URL, which want to shorten</param>
    /// <returns>Return short URL (data-type - string)</returns>
    public static string ShortenUrl(string LongUrl)
    {
        string result = "";

        string RequestUrl = "http://api.bitly.com/v3/shorten?login=" + "o_4ict2jfnsh" + "&apiKey=" + "R_7aa6b9a0e4eb4122b4b913f7f7cd7a31"
            + "&longUrl=" + HttpUtility.UrlEncode(LongUrl) + "&format=txt";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(RequestUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader ResponseStream = new StreamReader(response.GetResponseStream());
        result = ResponseStream.ReadToEnd().Replace("\n", "");
        return result;
    }

    public string GetUniqueFileName(string FileName, string PhysicalPath)
    {
        try
        {
            if (!System.IO.Directory.Exists(PhysicalPath))
            {
                System.IO.Directory.CreateDirectory(PhysicalPath);
            }
            string Extension = GetExtension(FileName, PhysicalPath);
            FileName = GetFileNameWithoutExtension(FileName, PhysicalPath);
            string FName = FileName.Replace("&", "_").Replace("!", "_").Replace("@", "_").Replace("#", "_").Replace("$", "_").Replace("%", "_").Replace("^", "_").Replace("*", "_").Replace("?", "_").Replace("/", "_").Replace("+", "_").Replace(",", "_").Replace("'", "_").Replace("<", "_").Replace(">", "_").Replace("\"", "_").Replace("\\", "_").Replace("{", "_").Replace("}", "_").Replace("[", "_").Replace("]", "_").Replace(":", "_").Replace(";", "_").Replace("|", "_").Replace("=", "_").Replace("`", "_").Replace("~", "_").Replace(" ", "_");
            FileName = FName;
            int i = 1;
            while (System.IO.File.Exists(PhysicalPath + FileName + Extension))
            {
                FileName = FName + i.ToString();
                i = i + 1;
            }
            return FileName + Extension;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            return "";
        }
    }
    public string GetExtension(string FileName, string PhysicalPath)
    {
        return System.IO.Path.GetExtension(PhysicalPath + FileName);
    }
    public string GetFileNameWithoutExtension(string FileName, string PhysicalPath)
    {
        return System.IO.Path.GetFileNameWithoutExtension(PhysicalPath + FileName);
    }

    public static string GetBaseURLTwitterImage
    {
        get
        {
            return GetBaseURL + "Images/Twitter/";
        }
    }

    public static string ConvertPhysicalPathToVertual(string SavePath)
    {
        return SavePath.Replace("\\", "/");
    }

    public static void SendMail1(string MailFrom, string MailTo, string MailSubject, string MailBody, string FilePath)
    {
        MailMessage Msg = new MailMessage();
        Msg.From = new MailAddress(MailFrom);
        Msg.To.Add(MailTo);
        Msg.Subject = MailSubject;
        Msg.Body = MailBody;
        Msg.IsBodyHtml = true;
        Attachment at = new Attachment(FilePath);
        Msg.Attachments.Add(at);
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtpout.secureserver.net";
        smtp.Port = 25;// 587;// 281;//587;//21;
        smtp.Credentials = new System.Net.NetworkCredential("info@gangdhari.com", "9829880533");
        smtp.Send(Msg);
    }

    /// <summary>
    /// Function for converting passed datetime to date in dd MMM yyyy format
    /// </summary>
    /// <param name="_Date">Pass DateTime or DateTime in string format</param>
    /// <returns>Short Date Format in dd MMM yyyy format</returns>
    public static string GetDateFormat(string _Date)
    {
        if (string.IsNullOrEmpty(_Date))
            return "";
        else
            return Convert.ToDateTime(_Date).ToString("dd MMM yyyy");
    }
}