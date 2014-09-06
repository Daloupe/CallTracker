Special Characters:
Regex Replace '|'
	Most data is split into groups and can be accessed with the | operator. It's worth noting fields like CMBS wont store non unique data eg the 3 prefix, or the 0/61 in mobile and landline numbers
	eg "CMBS|3$1$(2)0$3" will paste: "3112345607"

Concatenate '+'
	You can bind a field to paste multiple bits of data.
	eg "GSID|cmr {1}_+Fault.PR" will paste: "cmr 1234567890123_1234567"

Alternate Data ','
	Smart Paste will paste the first data that isn't empty.
	eg "DN,Username,Mobile" will paste Username if the DN field is empty.

Product Context '^'
	You can provide different lists of binds based on the selected product. If no match is found, it will use the first product.
	eg "^LATDN,Username,Mobile^ONCUsername,DN,Mobile" assuming both DN and Username fields have data and ONC is selected, it will paste Username. If you had LAT/LIP/DTV/NBN selected it would paste DN.


Data Types:
DN		 - 0(2)(94811234)
Username - (foo.bar)@optusnet.com.au
Mobile	 - 0(402758678)
ICON
CMBS	 - 3(1)-(123456)-(7)
Note 
GetICONNote
GetPRTemplate
IDok
Name
NameSplit.Title
	.First
	.Initial
	.Last
Address.Address
	.PropertyType
	.UnitNumber
	.PropertyNumber
	.StreetName
	.StreetType
	.Suburb
	.State
	.Postcode
Fault.Outcome
	.Action
	.PR
	.NPR
	.INC - (INC)(123456789)
	.APT - (APT)(123456789)
	.ITCase
	.ProblemStyle
	.ProductCode
	.Severity
	.Symptom
	.SymptomFull
	.SymptomGroup
	.AffectedService
Booking.Type
	.Date
	.Timeslot
Service.Equipment
	.Node - (33)(EB)_(123)
	.AVC	 - (AVC)(123456789)
	.CVC	 - (CVC)(123456789)
	.CSA	 - (CSA)(123456789)
	.NNI	 - (NNI)(123456789)
	.PRI	 - (PRI)(123456789)
	.GSID
	.Bras
	.Sip
	.NTDSN
	.CauPing
	.NitResults
	.ESN
	.AddressId
	.MTAMac	 - (1E):(F1):(4E):(8C):(2F)
	.ModemStatus
	.RFIssues
	.CMMac	 - (1E):(F1):(4E):(8C):(2F)
	.ModemSn
	.DownloadSpeed
	.UploadSpeed
	.Throttled
	.ModemIP - (192).(168).(0).(1)
	.DTVMsg
	.DTVSmartCard
	.DTVLot
	.DTVBox
	.Lights
	.MeTVMac - (1E):(F1):(4E):(8C):(2F)
	.MeTVSN

