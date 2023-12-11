using System;
using Newtonsoft.Json;

namespace RtzenAPIs.models
{

    public class Vendor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("businessUnit")]
        public BusinessUnit BusinessUnit { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }


        [JsonProperty("address")]
        public Address Address { get; set; }


        [JsonProperty("phone")]

        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("vendorContacts")]
        public List<VendorContact> VendorContacts { get; set; }

        [JsonProperty("acceptedPayments")]
        public AcceptedPayments AcceptedPayments { get; set; }
    }

    public class Address
    {


        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("addressLine3")]
        public string AddressLine3 { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }

    public class VendorContact
    {

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }

    public class VendorPayment
    {

        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("routingNumber")]
        public string RoutingNumber { get; set; }
    }

    public class AcceptedPayments
    {

        [JsonProperty("paymentCurrency")]
        public string PaymentCurrency { get; set; }

        [JsonProperty("vendorPayments")]
        public List<VendorPayment> VendorPayments { get; set; }
    }
}

