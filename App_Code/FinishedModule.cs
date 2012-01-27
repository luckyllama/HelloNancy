using System;
using System.Collections.Generic;
using System.Web;
using Nancy;
using Simple.Data;

public class FinishedModule : NancyModule {	
	public FinishedModule() : base("/fin") {

		Get["/"] = parameters => {
			return "Auf Wiedersehen, Intermark!";
		};
		
		Get["/test"] = parameters => {
			return "This is the Test route";
		};

        Get["/200"] = paramaters => {
            return 200;
        };

        Get["/404"] = parameters => {
	        return HttpStatusCode.NotFound;
        };

        Get["/json-result"] = parameters => {
            return Response.AsJson(new { first = "frank", middle = "the coolest", last = "hadder" });
        };

        Get["/xml-result"] = parameters => {
            return Response.AsXml(new Dealer { Id = 5, Name = "Hoover Toyota", Zip = "35226" });
        };

        Get["/fake-dealer-service"] = parameters => {
            var response = new Response();
            response.ContentType = "text\\xml";
            
            response.Contents = GetStringContents(
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            "<toyotaDealers xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" zipCode=\"35212\">" +
              "<dealer pd_id=\"SET\" region_code=\"0\" dealer_code=\"01059\" dealer_name=\"SERRA TOYOTA, INC.\" address1=\"1300 CENTER POINT PARKWAY\" address2=\"\" city=\"BIRMINGHAM\" state=\"AL\" zip_code=\"35215\" latitude=\"33.620632\" longitude=\"-86.685305\" url=\"http://www.serratoyota.com\" general_phone_number=\"(205)&amp;nbsp;838-4400\" tollfree_phone_number=\"2058384400\" general_fax_number=\"(205)&amp;nbsp;856-6565\" ecom_email_address=\"text@serratoyota.com\" isPMA=\"true\" scion_flag=\"true\" scion_dealer_name=\"Serra Scion\" scion_phone=\"(205)838-4400\" scion_dir_fax_num=\"\" scion_url=\"http://www.serrascion.com\" scion_email=\"sales@serrascion.com\" dealer_distance=\"6.415389908647418\" />" +
              "<dealer pd_id=\"SET\" region_code=\"0\" dealer_code=\"01061\" dealer_name=\"LIMBAUGH TOYOTA, INC.\" address1=\"2200 AVENUE T\" address2=\"\" city=\"BIRMINGHAM\" state=\"AL\" zip_code=\"35218\" latitude=\"33.507035\" longitude=\"-86.881857\" url=\"http://www.limbaughtoyota.com\" general_phone_number=\"(205)&amp;nbsp;780-0500\" tollfree_phone_number=\"2057800500\" general_fax_number=\"(205)&amp;nbsp;783-6592\" ecom_email_address=\"sales@limbaughtoyota.com\" isPMA=\"true\" scion_flag=\"true\" scion_dealer_name=\"Limbaugh Scion\" scion_phone=\"(205)780-0500\" scion_dir_fax_num=\"\" scion_url=\"http://www.limbaughscion.com\" scion_email=\"sales@limbaughscion.com\" dealer_distance=\"8.11975639539466\" />" +
              "<dealer pd_id=\"SET\" region_code=\"0\" dealer_code=\"01078\" dealer_name=\"HOOVER TOYOTA\" address1=\"2686 JOHN HAWKINS PARKWAY\" address2=\"\" city=\"HOOVER\" state=\"AL\" zip_code=\"35244\" latitude=\"33.359342\" longitude=\"-86.832354\" url=\"http://www.hoovertoyota.com\" general_phone_number=\"(205)&amp;nbsp;978-2600\" tollfree_phone_number=\"2059782600\" general_fax_number=\"(205)&amp;nbsp;978-2594\" ecom_email_address=\"sales@hoovertoyota.com\" isPMA=\"false\" scion_flag=\"true\" scion_dealer_name=\"Hoover Scion\" scion_phone=\"(205)823-3720\" scion_dir_fax_num=\"\" scion_url=\"http://www.hooverscion.com\" scion_email=\"sales@hooverscion.com\" dealer_distance=\"13.642451946281488\" />" +
              "<dealer pd_id=\"SET\" region_code=\"0\" dealer_code=\"01019\" dealer_name=\"SCOTT CRUMP TOYOTA\" address1=\"3815 HWY 78 E\" address2=\"\" city=\"JASPER\" state=\"AL\" zip_code=\"35501\" latitude=\"33.83891\" longitude=\"-87.23195\" url=\"http://www.scottcrumptoyota.com\" general_phone_number=\"(205)&amp;nbsp;221-3939\" tollfree_phone_number=\"2052213939\" general_fax_number=\"(205)&amp;nbsp;387-0382\" ecom_email_address=\"sales@johncrumptoyota.com\" isPMA=\"false\" scion_flag=\"true\" scion_dealer_name=\"Scott Crump Scion\" scion_phone=\"(205)221-3939\" scion_dir_fax_num=\"\" scion_url=\"http://www.scottcrumpscion.com\" scion_email=\"sales@scottcrumpscion.com\" dealer_distance=\"34.530976526823189\" />" +
              "<dealer pd_id=\"SET\" region_code=\"0\" dealer_code=\"01081\" dealer_name=\"TOYOTA OF SYLACAUGA\" address1=\"39765 HWY 280\" address2=\"\" city=\"SYLACAUGA\" state=\"AL\" zip_code=\"35150\" latitude=\"33.188524\" longitude=\"-86.304615\" url=\"http://www.toyotaofsylacauga.com\" general_phone_number=\"(256)&amp;nbsp;245-5251\" tollfree_phone_number=\"2562455251\" general_fax_number=\"(256)&amp;nbsp;249-8564\" ecom_email_address=\"Sales@toyotaofsylacauga.com\" isPMA=\"false\" scion_flag=\"false\" scion_dealer_name=\"\" scion_phone=\"\" scion_dir_fax_num=\"\" scion_email=\"\" dealer_distance=\"35.417010886329471\" />" +
            "</toyotaDealers>");

            return response;
        };
	}
        
    public class Dealer {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Zip { get; set; }
    }

    private static Action<System.IO.Stream> GetStringContents(string contents) {
        return stream => {
            var writer = new System.IO.StreamWriter(stream) { AutoFlush = true };
            writer.Write(contents);
        };
    }
}
