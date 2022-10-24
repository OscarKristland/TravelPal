using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TravelPal.Countries
{
    public enum AllCountries
    {
        Afghanistan,
        [Display(Name = "Åland Islands")]
        Åland_Islands,
        Albania,
        Algeria,
        [Display(Name = "American Samoa")]
        American_Samoa,
        Andorra,
        Angola,
        Anguilla,
        Antarctica,
        [Display(Name = "Antigua and Barbuda")]
        Antigua_and_Barbuda,
        Argentina,
        Armenia,
        Aruba,
        Australia,
        Austria,
        Azerbaijan,
        Bahamas,
        Bahrain,
        Bangladesh,
        Barbados,
        Belarus,
        Belgium,
        Belize,
        Benin,
        Bermuda,
        Bhutan,
        Bolivia,
        [Display(Name = "Bonaire, Sint, Eustatius, and Saba")]
        Bonaire_Sint_Eustatius_Saba,
        [Display(Name = "Bosnia and Herzegovina")]
        Bosnia_and_Herzegovina,
        Botswana,
        [Display(Name = "Bouvet Island")]
        Bouvet_Island,
        Brazil,
        [Display(Name = "British Indian Ocean Territory")]
        British_Indian_Ocean_Territory,
        [Display(Name = "Brunei Darussalam")]
        Brunei_Darussalam,
        Bulgaria,
        [Display(Name = "Burkina Faso")]
        Burkina_Faso,
        Burundi,
        Cambodia,
        Cameroon,
        Canada,
        [Display(Name = "Cape Verde")]
        Cape_Verde,
        [Display(Name = "Cayman Islands")]
        Cayman_Islands,
        [Display(Name = "Central African Republic")]
        Central_African_Republic,
        Chad,
        Chile,
        China,
        [Display(Name = "Christmas Island")]
        Christmas_Island,
        [Display(Name = "Cocos (Keeling) Islands")]
        Cocos_Keeling_Islands,
        Colombia,
        Comoros,
        Congo,
        [Display(Name = "Congo Democratic Republic")]
        Congo_Democratic_Republic,
        [Display(Name = "Cook Islands")]
        Cook_Islands,
        [Display(Name = "Costa Rica")]
        Costa_Rica,
        [Display(Name = "Côte D'Ivoire")]
        Cote_DIvoire,
        Croatia,
        Cuba,
        Curaçao,
        Cyprus,
        [Display(Name = "Czech Republic")]
        Czech_Republic,
        Denmark,
        Djibouti,
        Dominica,
        [Display(Name = "Dominican Republic")]
        Dominican_Republic,
        Ecuador,
        Egypt,
        [Display(Name = "El Salvador")]
        El_Salvador,
        [Display(Name = "Equatorial Guinea")]
        Equatorial_Guinea,
        Eritrea,
        Estonia,
        Ethiopia,
        [Display(Name = "Falkland Islands")]
        Falkland_Islands,
        [Display(Name = "Faroe Islands")]
        Faroe_Islands,
        Fiji,
        Finland,
        France,
        [Display(Name = "French Guiana")]
        French_Guiana,
        [Display(Name = "French Polynesia")]
        French_Polynesia,
        [Display(Name = "French Southern Territories")]
        French_Southern_Territories,
        Gabon,
        Gambia,
        Georgia,
        Germany,
        Ghana,
        Gibraltar,
        Greece,
        Greenland,
        Grenada,
        Guadeloupe,
        Guam,
        Guatemala,
        Guernsey,
        Guinea,
        [Display(Name = "Guinea Bissau")]
        Guinea_Bissau,
        Guyana,
        Haiti,
        [Display(Name = "Heard Island and McDonald Islands")]
        Heard_Island_Mcdonald_Islands,
        Honduras,
        HongKong,
        Hungary,
        Iceland,
        India,
        Indonesia,
        Iran,
        Iraq,
        Ireland,
        [Display(Name = "Isle of Man")]
        Isle_of_Man,
        Israel,
        Italy,
        Jamaica,
        Japan,
        Jersey,
        Jordan,
        Kazakhstan,
        Kenya,
        Kiribati,
        Korea,
        Kuwait,
        Kyrgyzstan,
        [Display(Name = "Lao People's Democratic Republic")]
        Lao_Peoples_Democratic_Republic,
        Latvia,
        Lebanon,
        Lesotho,
        Liberia,
        [Display(Name = "Libyan Arab Jamahiriya")]
        Libyan_Arab_Jamahiriya,
        Liechtenstein,
        Lithuania,
        Luxembourg,
        Macao,
        Macedonia,
        Madagascar,
        Malawi,
        Malaysia,
        Maldives,
        Mali,
        Malta,
        [Display(Name = "Marshall Islands")]
        Marshall_Islands,
        Martinique,
        Mauritania,
        Mauritius,
        Mayotte,
        Mexico,
        Micronesia,
        Moldova,
        Monaco,
        Mongolia,
        Montenegro,
        Montserrat,
        Morocco,
        Mozambique,
        Myanmar,
        Namibia,
        Nauru,
        Nepal,
        Netherlands,
        [Display(Name = "New Caledonia")]
        New_Caledonia,
        [Display(Name = "New Zealand")]
        New_Zealand,
        Nicaragua,
        Niger,
        Nigeria,
        Niue,
        [Display(Name = "Norfolk Island")]
        Norfolk_Island,
        [Display(Name = "Northern Mariana Islands")]
        Northern_Mariana_Islands,
        Norway,
        Oman,
        Pakistan,
        Palau,
        [Display(Name = "Palestinian Territory")]
        Palestinian_Territory,
        Panama,
        [Display(Name = "Papua New Guinea")]
        Papua_New_Guinea,
        Paraguay,
        Peru,
        Philippines,
        Pitcairn,
        Poland,
        Portugal,
        PuertoRico,
        Qatar,
        Reunion,
        Romania,
        [Display(Name = "Russian Federation")]
        Russian_Federation,
        Rwanda,
        [Display(Name = "Saint Barthelemy")]
        Saint_Barthelemy,
        [Display(Name = "Saint Helena")]
        Saint_Helena,
        [Display(Name = "Saint Kitts and Nevis")]
        Saint_Kitts_And_Nevis,
        [Display(Name = "Saint Lucia")]
        Saint_Lucia,
        [Display(Name = "Saint Martin")]
        Saint_Martin,
        [Display(Name = "Saint Pierre and Miquelon")]
        Saint_Pierre_and_Miquelon,
        [Display(Name = "Saint Vincent and Grenadines")]
        Saint_Vincent_and_Grenadines,
        Samoa,
        [Display(Name = "San Marino")]
        San_Marino,
        [Display(Name = "Sao Tome And Principe")]
        Sao_Tome_and_Principe,
        [Display(Name = "Saudi Arabia")]
        Saudi_Arabia,
        Senegal,
        Serbia,
        Seychelles,
        [Display(Name = "Sierra Leone")]
        Sierra_Leone,
        Singapore,
        [Display(Name = "Sint Maarten")]
        Sint_Maarten,
        Slovakia,
        Slovenia,
        [Display(Name = "Solomon Islands")]
        Solomon_Islands,
        Somalia,
        [Display(Name = "South Africa")]
        South_Africa,
        [Display(Name = "South Georgia and Sandwich Islands")]
        South_Georgia_and_Sandwich_Islands,
        [Display(Name = "South Sudan")]
        South_Sudan,
        Spain,
        [Display(Name = "Sri Lanka")]
        Sri_Lanka,
        Sudan,
        Suriname,
        [Display(Name = "Svalbard and Jan Mayen")]
        Svalbard_and_Jan_Mayen,
        Swaziland,
        Sweden,
        Switzerland,
        [Display(Name = "Syrian Arab Republic")]
        Syrian_Arab_Republic,
        Taiwan,
        Tajikistan,
        Tanzania,
        Thailand,
        [Display(Name = "Timor Leste")]
        Timor_Leste,
        Togo,
        Tokelau,
        Tonga,
        [Display(Name = "Trinidad and Tobago")]
        Trinidad_and_Tobago,
        Tunisia,
        Turkey,
        Turkmenistan,
        [Display(Name = "Turks and Caicos Islands")]
        Turks_and_Caicos_Islands,
        Tuvalu,
        Uganda,
        Ukraine,
        [Display(Name = "United Arab Emirates")]
        United_Arab_Emirates,
        [Display(Name = "United Kingdom")]
        United_Kingdom,
        [Display(Name = "United States")]
        United_States,
        [Display(Name = "United States Outlying Islands")]
        United_States_Outlying_Islands,
        Uruguay,
        Uzbekistan,
        Vanuatu,
        Vatican,
        Venezuela,
        Vietnam,
        [Display(Name = "Virgin Islands (British)")]
        Virgin_Islands_British,
        [Display(Name = "Virgin Islands (US)")]
        Virgin_Islands_US,
        [Display(Name = "Wallis and Fortuna")]
        Wallis_And_Futuna,
        [Display(Name = "Western Sahara")]
        Western_Sahara,
        Yemen,
        Zambia,
        Zimbabwe
    }
}
