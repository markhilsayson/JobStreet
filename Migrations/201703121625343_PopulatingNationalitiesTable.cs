namespace JobStreet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingNationalitiesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobseekers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        PermanentAddress = c.String(),
                        DateOfBirth = c.DateTime(),
                        Nationality_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nationalities", t => t.Nationality_Id)
                .Index(t => t.Nationality_Id);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(maxLength: 50),
                        Abbreviation = c.String(maxLength: 5),
                        Adjective = c.String(maxLength: 130),
                        Person = c.String(maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            Sql(@"INSERT INTO [dbo].[Nationalities](Country, Abbreviation, Adjective, Person )
VALUES  ( 'AMERICAN - USA','US','US (used attributively only, as in US aggression but not He is US)','a US citizen' ),
        ( 'ARGENTINA','AR','Argentinian','an Argentinian' ),
        ( 'AUSTRALIA','AU','Australian','an Australian' ),
        ( 'BAHAMAS','BS','Bahamian','a Bahamian' ),
        ( 'BELGIUM','BE','Belgian','a Belgian' ),
        ( 'BRAZIL','BR','Brazilian','a Brazilian' ),
        ( 'CANADA','CA','Canadian','a Canadian' ),
        ( 'CHINA','CN','Chinese','a Chinese' ),
        ( 'COLOMBIA','CO','Colombian','a Colombian' ),
        ( 'CUBA','CU','Cuban','a Cuban' ),
        ( 'DOMINICAN REPUBLIC','DO','Dominican','a Dominican' ),
        ( 'ECUADOR','EC','Ecuadorean','an Ecuadorean' ),
        ( 'EL SALVADOR','SV','Salvadorean','a Salvadorean' ),
        ( 'FRANCE','FR','French','a Frenchman, a Frenchwoman' ),
        ( 'GERMANY','DE','German','a German' ),
        ( 'GUATEMALA','GT','Guatemalan','a Guatemalan' ),
        ( 'HAITI','HT','Haitian','a Haitian' ),
        ( 'HONDURAS','HN','Honduran','a Honduran' ),
        ( 'INDIA','IN','Indian','an Indian' ),
        ( 'IRELAND','IE','Ireland','an Irishman, an Irishwoman' ),
        ( 'ISRAEL','IL','Israeli','an Israeli' ),
        ( 'ITALY','IT','Italian','an Italian' ),
        ( 'JAPAN','JP','Japanese','a Japanese' ),
        ( 'KOREA - REPUBLIC OF','KR','South Korean','a South Korean' ),
        ( 'MEXICO','MX','Mexican','a Mexican' ),
        ( 'NETHERLANDS','NL','Dutch','a Dutchman, a Dutchwoman, or a Netherlander' ),
        ( 'PHILIPPINES','PH','Philippine','a Filipino' ),
        ( 'SPAIN','ES','Spanish','a Spaniard' ),
        ( 'SWEDEN','SE','Swedish','a Swede' ),
        ( 'SWITZERLAND','CH','Swiss','a Swiss' ),
        ( 'TAIWAN - PROVINCE OF CHINA','TW','Taiwanese','a Taiwanese' ),
        ( 'UNITED KINGDOM','GB','UK (used attributively only, as in UK time but not He is UK) or British','a Briton' ),
        ( 'VENEZUELA - BOLIVARIAN REPUBLIC OF','VE','Venezuelan','a Venezuelan' ),
        ( 'VIET NAM','VN','Vietnamese','a Vietnamese' ),
        ( 'AFGHANISTAN','AF','Afghan','an Afghan' ),
        ( 'ÅLAND ISLANDS','AX', NULL, NULL ),
        ( 'ALBANIA','AL','Albanian','an Albanian' ),
        ( 'ALGERIA','DZ','Algerian','an Algerian' ),
        ( 'AMERICAN SAMOA','AS','Samoan','a Samoan' ),
        ( 'ANDORRA','AD','Andorran','an Andorran' ),
        ( 'ANGOLA','AO','Angolan','an Angolan' ),
        ( 'ANGUILLA','AI', NULL, NULL ),
        ( 'ANTARCTICA','AQ', NULL, NULL ),
        ( 'ANTIGUA AND BARBUDA','AG', NULL, NULL ),
        ( 'ARMENIA','AM','Armenian','an Armenian' ),
        ( 'ARUBA','AW', NULL, NULL ),
        ( 'AUSTRIA','AT','Austrian','an Austrian' ),
        ( 'AZERBAIJAN','AZ','Azerbaijani','an Azerbaijani' ),
        ( 'BAHRAIN','BH','Bahraini','a Bahraini' ),
        ( 'BANGLADESH','BD','Bangladeshi','a Bangladeshi' ),
        ( 'BARBADOS','BB','Barbadian','a Barbadian' ),
        ( 'BELARUS','BY','Belarusian or Belarusan','a Belarusian or a Belarusan' ),
        ( 'BELIZE','BZ','Belizean','a Belizean' ),
        ( 'BENIN','BJ','Beninese','a Beninese' ),
        ( 'BERMUDA','BM','Bermudian','a Bermudian' ),
        ( 'BHUTAN','BT','Bhutanese','a Bhutanese' ),
        ( 'BOLIVIA - PLURINATIONAL STATE OF','BO','Bolivian','a Bolivian' ),
        ( 'BONAIRE - SINT EUSTATIUS AND SABA','BQ', NULL, NULL ),
        ( 'BOSNIA AND HERZEGOVINA','BA','Bosnian','a Bosnian' ),
        ( 'BOTSWANA','BW','Botswanan','a Tswana' ),
        ( 'BOUVET ISLAND','BV', NULL, NULL ),
        ( 'BRITISH INDIAN OCEAN TERRITORY','IO', NULL, NULL ),
        ( 'BRUNEI DARUSSALAM','BN', NULL, NULL ),
        ( 'BULGARIA','BG','Bulgarian','a Bulgarian' ),
        ( 'BURKINA FASO','BF','Burkinese','a Burkinese' ),
        ( 'BURUNDI','BI','Burundian','a Burundian' ),
        ( 'CAMBODIA','KH','Cambodian','a Cambodian' ),
        ( 'CAMEROON','CM','Cameroonian','a Cameroonian' ),
        ( 'CAPE VERDE ISLANDS','CV','Cape Verdean','a Cape Verdean' ),
        ( 'CAYMAN ISLANDS','KY', NULL, NULL ),
        ( 'CENTRAL AFRICAN REPUBLIC','CF', NULL, NULL ),
        ( 'CHAD','TD','Chadian','a Chadian' ),
        ( 'CHILE','CL','Chilean','a Chilean' ),
        ( 'CHRISTMAS ISLAND','CX', NULL, NULL ),
        ( 'COCOS (KEELING) ISLANDS','CC', NULL, NULL ),
        ( 'COMOROS','KM', NULL, NULL ),
        ( 'CONGO','CG','Congolese','a Congolese' ),
        ( 'CONGO - THE DEMOCRATIC REPUBLIC OF THE','CD', NULL, NULL ),
        ( 'COOK ISLANDS','CK', NULL, NULL ),
        ( 'COSTA RICA','CR','Costa Rican','a Costa Rican' ),
        ( 'CÔTE D''IVOIRE','CI', NULL, NULL ),
        ( 'CROATIA','HR','Croat or Croatian','a Croat or a Croatian' ),
        ( 'CURAÇAO','CW', NULL, NULL ),
        ( 'CYPRUS','CY','Cypriot','a Cypriot' ),
        ( 'CZECH REPUBLIC','CZ','Czech','a Czech' ),
        ( 'DENMARK','DK','Danish','a Dane' ),
        ( 'DJIBOUTI','DJ','Djiboutian','a Djiboutian' ),
        ( 'DOMINICA','DM','Dominican','a Dominican' ),
        ( 'EGYPT','EG','Egyptian','an Egyptian' ),
        ( 'EQUATORIAL GUINEA','GQ', NULL, NULL ),
        ( 'ERITREA','ER','Eritrean','an Eritrean' ),
        ( 'ESTONIA','EE','Estonian','an Estonian' ),
        ( 'ETHIOPIA','ET','Ethiopian','an Ethiopian' ),
        ( 'FALKLAND ISLANDS (MALVINAS)','FK', NULL, NULL ),
        ( 'FAROE ISLANDS','FO', NULL, NULL ),
        ( 'FIJI','FJ','Fijian','a Fijian' ),
        ( 'FINLAND','FI','Finnish','a Finn' ),
        ( 'FRENCH GUIANA','GF', NULL, NULL ),
        ( 'FRENCH POLYNESIA','PF','French Polynesian','a French Polynesian' ),
        ( 'FRENCH SOUTHERN TERRITORIES','TF', NULL, NULL ),
        ( 'GABON','GA','Gabonese','a Gabonese' ),
        ( 'GAMBIA','GM','Gambian','a Gambian' ),
        ( 'GEORGIA','GE','Georgian','a Georgian' ),
        ( 'GHANA','GH','Ghanaian','a Ghanaian' ),
        ( 'GIBRALTAR','GI', NULL, NULL ),
        ( 'GREECE','GR','Greek','a Greek' ),
        ( 'GREENLAND','GL', NULL, NULL ),
        ( 'GRENADA','GD','Grenadian','a Grenadian' ),
        ( 'GUADELOUPE','GP', NULL, NULL ),
        ( 'GUAM','GU', NULL, NULL ),
        ( 'GUERNSEY','GG', NULL, NULL ),
        ( 'GUINEA','GN','Guinean','a Guinean' ),
        ( 'GUINEA-BISSAU','GW', NULL, NULL ),
        ( 'GUYANA','GY','Guyanese','a Guyanese' ),
        ( 'HEARD ISLAND AND MCDONALD ISLANDS','HM', NULL, NULL ),
        ( 'HOLY SEE (VATICAN CITY STATE)','VA', NULL, NULL ),
        ( 'HONG KONG','HK', NULL, NULL ),
        ( 'HUNGARY','HU','Hungarian','a Hungarian' ),
        ( 'ICELAND','IS','Icelandic','an Icelander' ),
        ( 'INDONESIA','ID','Indonesian','an Indonesian' ),
        ( 'IRAN - ISLAMIC REPUBLIC OF','IR','Iranian','an Iranian' ),
        ( 'IRAQ','IQ','Iraqi','an Iraqi' ),
        ( 'ISLE OF MAN','IM', NULL, NULL ),
        ( 'JAMAICA','JM','Jamaican','a Jamaican' ),
        ( 'JERSEY','JE', NULL, NULL ),
        ( 'JORDAN','JO','Jordanian','a Jordanian' ),
        ( 'KAZAKHSTAN','KZ','Kazakh','a Kazakh' ),
        ( 'KENYA','KE','Kenyan','a Kenyan' ),
        ( 'KIRIBATI','KI', NULL, NULL ),
        ( 'KOREA - DEMOCRATIC PEOPLE''S REPUBLIC OF','KP','North Korean','a North Korean' ),
        ( 'KUWAIT','KW','Kuwaiti','a Kuwaiti' ),
        ( 'KYRGYZSTAN','KG', NULL, NULL ),
        ( 'LAO PEOPLE''S DEMOCRATIC REPUBLIC','LA', NULL, NULL ),
        ( 'LATVIA','LV','Latvian','a Latvian' ),
        ( 'LEBANON','LB','Lebanese','a Lebanese' ),
        ( 'LESOTHO','LS', NULL, NULL ),
        ( 'LIBERIA','LR','Liberian','a Liberian' ),
        ( 'LIBYA','LY','Libyan','a Libyan' ),
        ( 'LIECHTENSTEIN','LI','-','a Liechtensteiner' ),
        ( 'LITHUANIA','LT','Lithuanian','a Lithuanian' ),
        ( 'LUXEMBOURG','LU','-','a Luxembourger' ),
        ( 'MACAO','MO', NULL, NULL ),
        ( 'MACEDONIA - THE FORMER YUGOSLAV REPUBLIC OF','MK', NULL, NULL ),
        ( 'MADAGASCAR','MG','Malagasy or Madagascan','a Malagasy or a Madagascan' ),
        ( 'MALAWI','MW','Malawian','a Malawian' ),
        ( 'MALAYSIA','MY','Malaysian','a Malaysian' ),
        ( 'MALDIVES','MV','Maldivian','a Maldivian' ),
        ( 'MALI','ML','Malian','a Malian' ),
        ( 'MALTA','MT','Maltese','a Maltese' ),
        ( 'MARSHALL ISLANDS','MH', NULL, NULL ),
        ( 'MARTINIQUE','MQ', NULL, NULL ),
        ( 'MAURITANIA','MR','Mauritanian','a Mauritanian' ),
        ( 'MAURITIUS','MU','Mauritian','a Mauritian' ),
        ( 'MAYOTTE','YT', NULL, NULL ),
        ( 'MICRONESIA - FEDERATED STATES OF','FM', NULL, NULL ),
        ( 'MOLDOVA - REPUBLIC OF','MD', NULL, NULL ),
        ( 'MONACO','MC','Monégasque or Monacan','a Monégasque or a Monacan' ),
        ( 'MONGOLIA','MN','Mongolian','a Mongolian' ),
        ( 'MONTENEGRO','ME','Montenegrin','a Montenegrin' ),
        ( 'MONTSERRAT','MS', NULL, NULL ),
        ( 'MOROCCO','MA','Moroccan','a Moroccan' ),
        ( 'MOZAMBIQUE','MZ','Mozambican','a Mozambican' ),
        ( 'MYANMAR','MM', NULL, NULL ),
        ( 'NAMIBIA','NA','Namibian','a Namibian' ),
        ( 'NAURU','NR', NULL, NULL ),
        ( 'NEPAL','NP','Nepalese','a Nepalese' ),
        ( 'NEW CALEDONIA','NC', NULL, NULL ),
        ( 'NEW ZEALAND','NZ','New Zealand (used attributively only, as in New Zealand butter but not He is New Zealand)','a New Zealander' ),
        ( 'NICARAGUA','NI','Nicaraguan','a Nicaraguan' ),
        ( 'NIGER','NE','Nigerien','a Nigerien' ),
        ( 'NIGERIA','NG','Nigerian','a Nigerian' ),
        ( 'NIUE','NU', NULL, NULL ),
        ( 'NORFOLK ISLAND','NF', NULL, NULL ),
        ( 'NORTHERN MARIANA ISLANDS','MP', NULL, NULL ),
        ( 'NORWAY','NO','Norwegian','a Norwegian' ),
        ( 'OMAN','OM','Omani','an Omani' ),
        ( 'PAKISTAN','PK','Pakistani','a Pakistani' ),
        ( 'PALAU','PW', NULL, NULL ),
        ( 'PALESTINE - STATE OF','PS', NULL, NULL ),
        ( 'PANAMA','PA','Panamanian','a Panamanian' ),
        ( 'PAPUA NEW GUINEA','PG','Papua New Guinean or Guinean','a Papua New Guinean or a Guinean' ),
        ( 'PARAGUAY','PY','Paraguayan','a Paraguayan' ),
        ( 'PERU','PE','Peruvian','a Peruvian' ),
        ( 'PITCAIRN','PN', NULL, NULL ),
        ( 'POLAND','PL','Polish','a Pole' ),
        ( 'PORTUGAL','PT','Portuguese','a Portuguese' ),
        ( 'PUERTO RICO','PR', NULL, NULL ),
        ( 'QATAR','QA','Qatari','a Qatari' ),
        ( 'RÉUNION','RE', NULL, NULL ),
        ( 'ROMANIA','RO','Romanian','a Romanian' ),
        ( 'RUSSIAN FEDERATION','RU', NULL, NULL ),
        ( 'RWANDA','RW','Rwandan','a Rwandan' ),
        ( 'SAINT BARTHÉLEMY','BL', NULL, NULL ),
        ( 'SAINT HELENA - ASCENSION AND TRISTAN DA CUNHA','SH', NULL, NULL ),
        ( 'SAINT KITTS AND NEVIS','KN', NULL, NULL ),
        ( 'SAINT LUCIA','LC', NULL, NULL ),
        ( 'SAINT MARTIN (FRENCH PART)','MF', NULL, NULL ),
        ( 'SAINT PIERRE AND MIQUELON','PM', NULL, NULL ),
        ( 'SAINT VINCENT AND THE GRENADINES','VC', NULL, NULL ),
        ( 'SAMOA','WS', NULL, NULL ),
        ( 'SAN MARINO','SM', NULL, NULL ),
        ( 'SAO TOME AND PRINCIPE','ST', NULL, NULL ),
        ( 'SAUDI ARABIA','SA','Saudi Arabian or Saudi','a Saudi Arabian or a Saudi' ),
        ( 'SENEGAL','SN','Senegalese','a Senegalese' ),
        ( 'SERBIA','RS','Serb or Serbian','a Serb or a Serbian' ),
        ( 'SEYCHELLES','SC', NULL, NULL ),
        ( 'SIERRA LEONE','SL','Sierra Leonian','a Sierra Leonian' ),
        ( 'SINGAPORE','SG','Singaporean','a Singaporean' ),
        ( 'SINT MAARTEN (DUTCH PART)','SX', NULL, NULL ),
        ( 'SLOVAKIA','SK','Slovak','a Slovak' ),
        ( 'SLOVENIA','SI','Slovene or Slovenian','a Slovene or a Slovenian' ),
        ( 'SOLOMON ISLANDS','SB','-','a Solomon Islander' ),
        ( 'SOMALIA','SO','Somali','a Somali' ),
        ( 'SOUTH AFRICA','ZA','South African','a South African' ),
        ( 'SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS','GS', NULL, NULL ),
        ( 'SOUTH SUDAN','SS', NULL, NULL ),
        ( 'SRI LANKA','LK','Sri Lankan','a Sri Lankan' ),
        ( 'SUDAN','SD','Sudanese','a Sudanese' ),
        ( 'SURINAME','SR','Surinamese','a Surinamer or a Surinamese' ),
        ( 'SVALBARD AND JAN MAYEN','SJ', NULL, NULL ),
        ( 'SWAZILAND','SZ','Swazi','a Swazi' ),
        ( 'SYRIAN ARAB REPUBLIC','SY', NULL, NULL ),
        ( 'TAJIKISTAN','TJ','Tajik or Tadjik','a Tajik or a Tadjik' ),
        ( 'TANZANIA - UNITED REPUBLIC OF','TZ', NULL, NULL ),
        ( 'THAILAND','TH','Thai','a Thai' ),
        ( 'TIMOR-LESTE','TL', NULL, NULL ),
        ( 'TOGO','TG','Togolese','a Togolese' ),
        ( 'TOKELAU','TK', NULL, NULL ),
        ( 'TONGA','TO', NULL, NULL ),
        ( 'TRINIDAD AND TOBAGO','TT','Trinidadian','a Trinidadian' ),
        ( 'TUNISIA','TN','Tunisian','a Tunisian' ),
        ( 'TURKEY','TR','Turkish','a Turk' ),
        ( 'TURKMENISTAN','TM','Turkmen or Turkoman','a Turkmen or a Turkoman' ),
        ( 'TURKS AND CAICOS ISLANDS','TC', NULL, NULL ),
        ( 'TUVALU','TV','Tuvaluan','a Tuvaluan' ),
        ( 'UGANDA','UG','Ugandan','a Ugandan' ),
        ( 'UKRAINE','UA','Ukrainian','a Ukrainian' ),
        ( 'UNITED ARAB EMIRATES','AE', NULL, NULL ),
        ( 'UNITED STATES MINOR OUTLYING ISLANDS','UM', NULL, NULL ),
        ( 'URUGUAY','UY','Uruguayan','a Uruguayan' ),
        ( 'UZBEKISTAN','UZ','Uzbek','an Uzbek' ),
        ( 'VANUATU','VU','Vanuatuan','a Vanuatuan' ),
        ( 'VIRGIN ISLANDS - BRITISH','VG', NULL, NULL ),
        ( 'VIRGIN ISLANDS - U.S.','VI', NULL, NULL ),
        ( 'WALLIS AND FUTUNA','WF', NULL, NULL ),
        ( 'WESTERN SAHARA','EH', NULL, NULL ),
        ( 'YEMEN','YE','Yemeni','a Yemeni' ),
        ( 'ZAMBIA','ZM','Zambian','a Zambian' )

");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Jobseekers", "Nationality_Id", "dbo.Nationalities");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Jobseekers", new[] { "Nationality_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Nationalities");
            DropTable("dbo.Jobseekers");
        }
    }
}
