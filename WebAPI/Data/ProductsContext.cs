using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities.Products;
using System.IO;

namespace WebAPI.Data;

public class ProductsContext(DbContextOptions<ProductsContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<SubCategory> Subcategories => Set<SubCategory>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var specificationComparer = new ValueComparer<List<Specification>>(
            (c1, c2) => c1.SequenceEqual(c2), // Comparación por secuencia
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // Cálculo del hash
            c => c.ToList() // Clon para snapshots
        );

        modelBuilder.Entity<Product>()
            .Property(p => p.Specifications)
            .HasConversion(
                v => JsonSerializer.Serialize(v, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull }),
                v => JsonSerializer.Deserialize<List<Specification>>(v, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull }) ?? new List<Specification>())
            .Metadata.SetValueComparer(specificationComparer);
        
        modelBuilder.Entity<Brand>().HasData(
    new   {
        Id= 1,
        Name = "DISFAVIL"
    },
    new  {
        Id= 2,
        Name= "ZUUM"
    },
    new {
        Id= 3,
        Name= "ENSURE"
    },
    new {
        Id= 4,
        Name= "ALKOH"
    },
    new {
        Id= 5,
        Name= "VESA"
    },
    new {
        Id= 6,
        Name= "SUPERIOR"
    },
    new {
        Id= 7,
        Name= "SAL ANDREWS"
    },
    new {
        Id= 8,
        Name= "ALKA-SELTZER"
    },
    new {
        Id= 9,
        Name= "HIDRAVIDA"
    },
    new {
        Id= 10,
        Name= "PANADOL"
    },
    new {
        Id= 11,
        Name= "MK"
    },
    new {
        Id= 12,
        Name= "GLUCERNA"
    },
    new {
        Id= 13,
        Name= "CASTILLA"
    },
    new {
        Id= 14,
        Name= "GENESIS"
    },
    new {
        Id= 15,
        Name= "VITAFLENACO"
    },
    new {
        Id= 16,
        Name= "CERAVE"
    },
    new {
        Id= 17,
        Name= "ATLEVIT"
    },
    new {
        Id= 18,
        Name= "HANSAPLAST"
    },
    new {
        Id= 19,
        Name= "ALKA EXTREME"
    },
    new {
        Id= 20,
        Name= "TUMS"
    },
    new {
        Id= 21,
        Name= "SANTA FE NATURA"
    },
    new {
        Id= 22,
        Name= "EUCERIN"
    },
    new {
        Id= 23,
        Name= "EXCELLENT"
    },
    new {
        Id= 24,
        Name= "TYLENOL"
    },
    new {
        Id= 25,
        Name= "PEDIASURE"
    },
    new {
        Id= 26,
        Name= "DEOPIES"
    },
    new {
        Id= 27,
        Name= "TABCIN"
    },
    new {
        Id= 28,
        Name= "AFFECTIVE"
    },
    new {
        Id= 29,
        Name= "ADVIL"
    },
    new {
        Id= 30,
        Name= "GATORADE"
    },
    new {
        Id= 31,
        Name= "DORIVAL"
    },
    new {
        Id= 32,
        Name= "METAMUCIL"
    },
    new {
        Id= 33,
        Name= "ASPIRINA"
    },
    new {
        Id= 34,
        Name= "VIROGRIP"
    },
    new {
        Id= 35,
        Name= "SAVORÂ"
    },
    new {
        Id= 36,
        Name= "VIJOSA"
    },
    new {
        Id= 37,
        Name= "GELA-KIN"
    },
    new {
        Id= 38,
        Name= "PEDEX"
    },
    new {
        Id= 39,
        Name= "INFASA"
    },
    new {
        Id= 40,
        Name= "SIETE MARES"
    },
    new {
        Id= 41,
        Name= "VICK"
    },
    new {
        Id= 42,
        Name= "VICK VAPORUB"
    },
    new {
        Id= 43,
        Name= "LA BONNE VIE"
    },
    new {
        Id= 44,
        Name= "DRIVE MEDICAL"
    },
    new {
        Id= 45,
        Name= "FARMANDINA"
    },
    new {
        Id= 46,
        Name= "MEDIMART"
    },
    new {
        Id= 47,
        Name= "PRUDENCE"
    },
    new {
        Id= 48,
        Name= "QUALIPHARM"
    },
    new {
        Id= 49,
        Name= "ALKA AD"
    },
    new {
        Id= 50,
        Name= "JOHNSON & JOHNSON"
    },
    new {
        Id= 51,
        Name= "PEPTO BISMOL"
    },
    new {
        Id= 52,
        Name= "PASINERVA"
    },
    new {
        Id= 53,
        Name= "VITABIOTICS"
    },
    new {
        Id= 54,
        Name= "BENET"
    },
    new {
        Id= 55,
        Name= "BEPANTHENE"
    },
    new {
        Id= 56,
        Name= "BAYER"
    },
    new {
        Id= 57,
        Name= "CUREBAND"
    },
    new {
        Id= 58,
        Name= "PIEX"
    },
    new {
        Id= 59,
        Name= "CENTRUM"
    },
    new {
        Id= 60,
        Name= "GOOD BRANDS"
    },
    new {
        Id= 61,
        Name= "DEL PILAR"
    },
    new {
        Id= 62,
        Name= "NEXCARE"
    },
    new {
        Id= 63,
        Name= "LA ROCHE-POSAY"
    },
    new {
        Id= 64,
        Name= "ENTEREX"
    },
    new {
        Id= 65,
        Name= "MASCARA"
    },
    new {
        Id= 66,
        Name= "REDOXITOS"
    },
    new {
        Id= 67,
        Name= "OMRON"
    },
    new {
        Id= 68,
        Name= "DUREX"
    },
    new {
        Id= 69,
        Name= "AMBIDERM"
    },
    new {
        Id= 70,
        Name= "DONOVAN"
    },
    new {
        Id= 71,
        Name= "GUTIS"
    },
    new {
        Id= 72,
        Name= "CANESTEN"
    },
    new {
        Id= 73,
        Name= "VIVE"
    },
    new {
        Id= 74,
        Name= "SUKROL"
    },
    new {
        Id= 75,
        Name= "BEBERÂ"
    },
    new {
        Id= 76,
        Name= "NEXT-TABS"
    },
    new {
        Id= 77,
        Name= "ALKA  GASTRIC"
    },
    new {
        Id= 78,
        Name= "ROEMMERS"
    },
    new {
        Id= 79,
        Name= "MEDIHEALTH"
    },
    new {
        Id= 80,
        Name= "MENARINI"
    },
    new {
        Id= 81,
        Name= "REDOXON"
    },
    new {
        Id= 82,
        Name= "CAPLIN POINT LABORAT"
    },
    new {
        Id= 83,
        Name= "UNESIA"
    },
    new {
        Id= 84,
        Name= "CEBION"
    },
    new {
        Id= 85,
        Name= "RENU"
    },
    new {
        Id= 86,
        Name= "MEDIPRODUCTS"
    },
    new {
        Id= 87,
        Name= "NEUMONIL"
    },
    new {
        Id= 88,
        Name= "VISINA"
    },
    new {
        Id= 89,
        Name= "NIPRO"
    },
    new {
        Id= 90,
        Name= "ALDO UNION"
    },
    new {
        Id= 91,
        Name= "FARKOT"
    },
    new {
        Id= 92,
        Name= "ANCALMO"
    },
    new {
        Id= 93,
        Name= "VITAL FUERTE"
    },
    new {
        Id= 94,
        Name= "ALCON"
    },
    new {
        Id= 95,
        Name= "CARDIOASPIRINA"
    },
    new {
        Id= 96,
        Name= "DIQUIVA"
    },
    new {
        Id= 97,
        Name= "ISDIN"
    },
    new {
        Id= 98,
        Name= "NUTRAMEDIX"
    },
    new {
        Id= 99,
        Name= "ALEVE"
    },
    new {
        Id= 100,
        Name= "BALLENA AZUL"
    },
    new {
        Id= 101,
        Name= "FRYCIA"
    },
    new {
        Id= 102,
        Name= "ABL PHARMA"
    },
    new {
        Id= 103,
        Name= "GRIIN"
    },
    new {
        Id= 104,
        Name= "SIN MARCA"
    },
    new {
        Id= 105,
        Name= "COFAL"
    },
    new {
        Id= 106,
        Name= "B&J"
    },
    new {
        Id= 107,
        Name= "VICHY"
    },
    new {
        Id= 108,
        Name= "K-Y GEL"
    },
    new {
        Id= 109,
        Name= "PEDIALYTE"
    },
    new {
        Id= 110,
        Name= "NEUROFORTAN"
    },
    new {
        Id= 111,
        Name= "BABE"
    },
    new {
        Id= 112,
        Name= "CHINOIN"
    },
    new {
        Id= 113,
        Name= "ABBOTT CFR"
    },
    new {
        Id= 114,
        Name= "PIERSAN"
    },
    new {
        Id= 115,
        Name= "MERCK"
    },
    new {
        Id= 116,
        Name= "JALOMA"
    },
    new {
        Id= 117,
        Name= "LEUKOPLAST"
    },
    new {
        Id= 118,
        Name= "FERRER"
    },
    new {
        Id= 119,
        Name= "DOLOKALORUB"
    },
    new {
        Id= 120,
        Name= "BABARIA"
    },
    new {
        Id= 121,
        Name= "GENERIX"
    },
    new {
        Id= 122,
        Name= "ASOFARMA"
    },
    new {
        Id= 123,
        Name= "QUINFICA"
    },
    new {
        Id= 124,
        Name= "LEMON GRASS"
    },
    new {
        Id= 125,
        Name= "BONIN"
    },
    new {
        Id= 126,
        Name= "PROCTER & GAMBLE"
    },
    new {
        Id= 127,
        Name= "SANOFI CHC"
    },
    new {
        Id= 128,
        Name= "COREGA"
    },
    new {
        Id= 129,
        Name= "ISIS PHARMA"
    },
    new {
        Id= 130,
        Name= "UNIPHARM"
    },
    new {
        Id= 131,
        Name= "SCOTT"
    },
    new {
        Id= 132,
        Name= "GMS"
    },
    new {
        Id= 133,
        Name= "VERDE VITA"
    },
    new {
        Id= 134,
        Name= "CHEMILCO"
    },
    new {
        Id= 135,
        Name= "QUIFARMA"
    },
    new {
        Id= 136,
        Name= "VITAMIN SHOPPE"
    },
    new {
        Id= 137,
        Name= "BMA PHARMA"
    },
    new {
        Id= 138,
        Name= "ICN GROSMAN"
    },
    new {
        Id= 139,
        Name= "EXELTIS"
    },
    new {
        Id= 140,
        Name= "MED PHARMA"
    },
    new {
        Id= 141,
        Name= "GEX"
    },
    new {
        Id= 142,
        Name= "GASTRO-BISMOL"
    },
    new {
        Id= 143,
        Name= "CIRUELAX"
    },
    new {
        Id= 144,
        Name= "GNC"
    },
    new {
        Id= 145,
        Name= "BAYKID"
    },
    new {
        Id= 146,
        Name= "ACIERTO"
    },
    new {
        Id= 147,
        Name= "HIMALAYA"
    },
    new {
        Id= 148,
        Name= "LEONFLAX"
    },
    new {
        Id= 149,
        Name= "PHILLIPS"
    },
    new {
        Id= 150,
        Name= "RUSSELL STOVER"
    },
    new {
        Id= 151,
        Name= "ACON"
    },
    new {
        Id= 152,
        Name= "GLAXOSMITHKLINE"
    },
    new {
        Id= 153,
        Name= "PROTEINOL"
    },
    new {
        Id= 154,
        Name= "SANTA FE"
    },
    new {
        Id= 155,
        Name= "CARDIO VITAL"
    },
    new {
        Id= 156,
        Name= "DENK"
    },
    new {
        Id= 157,
        Name= "LANCASCO"
    },
    new {
        Id= 158,
        Name= "BENADRYL"
    },
    new {
        Id= 159,
        Name= "LAXMI PHARMAC."
    },
    new {
        Id= 160,
        Name= "VIZCAINO"
    },
    new {
        Id= 161,
        Name= "LAINEZ"
    },
    new {
        Id= 162,
        Name= "ZEPOL"
    },
    new {
        Id= 163,
        Name= "BUSSIE"
    },
    new {
        Id= 164,
        Name= "BIODERMA"
    },
    new {
        Id= 165,
        Name= "SEBAPHARMA"
    },
    new {
        Id= 166,
        Name= "MEFASA"
    },
    new {
        Id= 167,
        Name= "PROFOOT"
    },
    new {
        Id= 168,
        Name= "GHL INTERNACION"
    },
    new {
        Id= 169,
        Name= "BAYER HEALTHCARE P"
    },
    new {
        Id= 170,
        Name= "SAFEGUARD"
    },
    new {
        Id= 171,
        Name= "JANSSEN"
    },
    new {
        Id= 172,
        Name= "CHOLSAMAJ"
    },
    new {
        Id= 173,
        Name= "PINGUINO"
    },
    new {
        Id= 174,
        Name= "NIKZON"
    },
    new {
        Id= 175,
        Name= "ROCHE"
    },
    new {
        Id= 176,
        Name= "PRUMISA"
    },
    new {
        Id= 177,
        Name= "ABBOTT LAB."
    },
    new {
        Id= 178,
        Name= "GUASURE"
    },
    new {
        Id= 179,
        Name= "GRUPO FARMA"
    },
    new {
        Id= 180,
        Name= "ROWE"
    },
    new {
        Id= 181,
        Name= "BOEHRINGER INGELHEIM"
    },
    new {
        Id= 182,
        Name= "GLOBAL FARMA"
    },
    new {
        Id= 183,
        Name= "ACCU-ANSWER"
    },
    new {
        Id= 184,
        Name= "BIOCLEAN"
    },
    new {
        Id= 185,
        Name= "LAFAGE"
    },
    new {
        Id= 186,
        Name= "DAVIS LAB."
    },
    new {
        Id= 187,
        Name= "ODDENT"
    },
    new {
        Id= 188,
        Name= "CHURCH&DWIGHT"
    },
    new {
        Id= 189,
        Name= "PROCAPS"
    },
    new {
        Id= 190,
        Name= "FERRIDOCE"
    },
    new {
        Id= 191,
        Name= "HEIDELG"
    },
    new {
        Id= 192,
        Name= "ROWA WAGNER"
    },
    new {
        Id= 193,
        Name= "ALFER"
    },
    new {
        Id= 194,
        Name= "PHARMALAT"
    },
    new {
        Id= 195,
        Name= "ASTRA ZENECA"
    },
    new {
        Id= 196,
        Name= "EUROFARMA"
    },
    new {
        Id= 197,
        Name= "PAILL"
    },
    new {
        Id= 198,
        Name= "BIO TRUE"
    },
    new {
        Id= 199,
        Name= "LABORATORIOS MIDI"
    },
    new {
        Id= 200,
        Name= "TERAMED"
    },
    new {
        Id= 201,
        Name= "LUNDBECK"
    },
    new {
        Id= 202,
        Name= "ORGANON"
    },
    new {
        Id= 203,
        Name= "ACINO PHARMA"
    },
    new {
        Id= 204,
        Name= "ESCUDO"
    },
    new {
        Id= 205,
        Name= "NUTRISON"
    },
    new {
        Id= 206,
        Name= "NOVARTIS PHARMA"
    },
    new {
        Id= 207,
        Name= "GLAXO PHARMA"
    },
    new {
        Id= 208,
        Name= "PFIZER"
    },
    new {
        Id= 209,
        Name= "VIU"
    },
    new {
        Id= 210,
        Name= "BENESTAR"
    },
    new {
        Id= 211,
        Name= "BENESSI"
    },
    new {
        Id= 212,
        Name= "CRAYOLA SILLY SCENTS"
    },
    new {
        Id= 213,
        Name= "EXELTIS NOVARTIS"
    },
    new {
        Id= 214,
        Name= "HIDRATOMIC"
    },
    new {
        Id= 215,
        Name= "SERVIER"
    },
    new {
        Id= 216,
        Name= "PHARBEST"
    },
    new {
        Id= 217,
        Name= "VITAGEL"
    },
    new {
        Id= 218,
        Name= "OSHI"
    },
    new {
        Id= 219,
        Name= "MERZ"
    },
    new {
        Id= 220,
        Name= "CHEMINTER"
    },
    new {
        Id= 221,
        Name= "SANOFI"
    },
    new {
        Id= 222,
        Name= "FARMAMEDICA"
    },
    new {
        Id= 223,
        Name= "FUTURO"
    },
    new {
        Id= 224,
        Name= "GARDEN HOUSE"
    },
    new {
        Id= 225,
        Name= "NOVARTIS-COHEN"
    },
    new {
        Id= 226,
        Name= "DRIVE DEVILBISS HEALTHCARE"
    },
    new {
        Id= 227,
        Name= "SAVAL"
    },
    new {
        Id= 228,
        Name= "VIFOR"
    },
    new {
        Id= 229,
        Name= "IPROFASA"
    },
    new {
        Id= 230,
        Name= "BONLIFE"
    },
    new {
        Id= 231,
        Name= "MILAGRO DE LA SELVA"
    },
    new {
        Id= 232,
        Name= "OM"
    },
    new {
        Id= 233,
        Name= "HARRY POTTER"
    },
    new {
        Id= 234,
        Name= "MEDITEMP"
    },
    new {
        Id= 235,
        Name= "PANALAB"
    },
    new {
        Id= 236,
        Name= "CHALVER"
    },
    new {
        Id= 237,
        Name= "KRAL"
    },
    new {
        Id= 238,
        Name= "CHILE"
    },
    new {
        Id= 239,
        Name= "QG5"
    },
    new {
        Id= 240,
        Name= "SESDERMA S.A"
    },
    new {
        Id= 241,
        Name= "GRUNENTHAL"
    },
    new {
        Id= 242,
        Name= "HIDRISAGE"
    },
    new {
        Id= 243,
        Name= "INTECFA"
    },
    new {
        Id= 244,
        Name= "ROHAPHARMA"
    },
    new {
        Id= 245,
        Name= "EISAI"
    },
    new {
        Id= 246,
        Name= "ROTTA"
    },
    new {
        Id= 247,
        Name= "MERCK SHARP & D"
    },
    new {
        Id= 248,
        Name= "QUIMIFAR"
    },
    new {
        Id= 249,
        Name= "ASPEN"
    },
    new {
        Id= 250,
        Name= "ARSAL"
    },
    new {
        Id= 251,
        Name= "BIOTA"
    },
    new {
        Id= 252,
        Name= "PHARMAKON"
    },
    new {
        Id= 253,
        Name= "ANGELINI"
    },
    new {
        Id= 254,
        Name= "OFTISOL"
    },
    new {
        Id= 255,
        Name= "PHISA"
    },
    new {
        Id= 256,
        Name= "SANDOZ"
    },
    new {
        Id= 257,
        Name= "LEVEN"
    },
    new {
        Id= 258,
        Name= "NOVARTIS"
    },
    new {
        Id= 259,
        Name= "BALIARDA"
    },
    new {
        Id= 260,
        Name= "SILANES"
    },
    new {
        Id= 261,
        Name= "SOPHIA"
    },
    new {
        Id= 262,
        Name= "BIOCODEX"
    },
    new {
        Id= 263,
        Name= "LANSIER"
    },
    new {
        Id= 264,
        Name= "MEGALABS"
    },
    new {
        Id= 265,
        Name= "PROTEC"
    },
    new {
        Id= 266,
        Name= "WELLCO"
    },
    new {
        Id= 267,
        Name= "LUVECK"
    },
    new {
        Id= 268,
        Name= "MICROLIFE"
    },
    new {
        Id= 269,
        Name= "TOP MODEL"
    },
    new {
        Id= 270,
        Name= "ELI LILLY"
    },
    new {
        Id= 271,
        Name= "JR PHARMA"
    },
    new {
        Id= 272,
        Name= "PRODES"
    },
    new {
        Id= 273,
        Name= "ALLERGAN"
    },
    new {
        Id= 274,
        Name= "BAGO"
    },
    new {
        Id= 275,
        Name= "SANAMIEL"
    },
    new {
        Id= 276,
        Name= "BEBES LLORONES"
    },
    new {
        Id= 277,
        Name= "RUBIOS"
    },
    new {
        Id= 278,
        Name= "SANOFI-ETICO"
    },
    new {
        Id= 279,
        Name= "SAN GERMAN"
    },
    new {
        Id= 280,
        Name= "MEMBER'S MARK"
    },
    new {
        Id= 281,
        Name= "ROSCOE"
    },
    new {
        Id= 282,
        Name= "GRISI"
    },
    new {
        Id= 283,
        Name= "GENFAR"
    },
    new {
        Id= 284,
        Name= "CUMLAUDE LAB"
    },
    new {
        Id= 285,
        Name= "EQUATE"
    },
    new {
        Id= 286,
        Name= "BOSTON"
    },
    new {
        Id= 287,
        Name= "NIELSEN BAINBRIDGE"
    }
        );

        modelBuilder.Entity<Category>().HasData(
    new  {
        Id = 1,
        Name = "Sistema digestivo y Antiparasitarios"
    },
    new  {
        Id = 2,
        Name = "OTC"
    },
    new  {
        Id = 3,
        Name = "Estomacales"
    },
    new  {
        Id = 4,
        Name = "Analgésicos"
    },
    new  {
        Id = 5,
        Name = "Dolor e inflamación"
    },
    new  {
        Id = 6,
        Name = "Multivitamínicos, Suplementos & Sistema Óseo"
    },
    new  {
        Id = 7,
        Name = "Respiratorios"
    },
    new  {
        Id = 8,
        Name = "Dermatología"
    },
    new  {
        Id = 9,
        Name = "Cuidado Personal"
    },
    new  {
        Id = 10,
        Name = "Antiviral, gripe y tos"
    },
    new  {
        Id = 11,
        Name = "Vitaminas y Suplementos"
    },
    new  {
        Id = 12,
        Name = "Asma, alergias y nasal"
    },
    new  {
        Id = 13,
        Name = "Bienestar, equipo médico y soluciones hospitalarias"
    },
    new  {
        Id = 14,
        Name = "Cuidado de los Pies"
    },
    new  {
        Id = 15,
        Name = "Anticonceptivos, hormonal y salud sexual"
    },
    new  {
        Id = 16,
        Name = "Cardiovascular & Hipertensivo"
    },
    new  {
        Id = 17,
        Name = "Material de Curación"
    },
    new  {
        Id = 18,
        Name = "Antimicótico"
    },
    new  {
        Id = 19,
        Name = "Sistema Nervioso"
    },
    new  {
        Id = 20,
        Name = "Bienestar Sexual"
    },
    new  {
        Id = 21,
        Name = "Oftálmicos y Óticos"
    },
    new  {
        Id = 22,
        Name = "Salud Bucal, Oftalmológico & Oído"
    },
    new  {
        Id = 23,
        Name = "Diabetes"
    },
    new  {
        Id = 24,
        Name = "Diabetes y tiroides"
    },
    new  {
        Id = 25,
        Name = "Embarazo & lactancia infantil"
    },
    new  {
        Id = 26,
        Name = "Medicamentos de Alta Especialidad"
    },
    new  {
        Id = 27,
        Name = "Colesterol y Triglicérido"
    },
    new  {
        Id = 28,
        Name = "Sistema Urinario"
    },
    new  {
        Id = 29,
        Name = "Antibiótico"
    }
            );

        modelBuilder.Entity<SubCategory>().HasData(
    new {
        Id = 1,
        Name = "Sueros",
        CategoryId = 3
    },
    new {
        Id = 2,
        Name = "Dolor",
        CategoryId = 4
    },
    new {
        Id = 3,
        Name = "Resfríos",
        CategoryId = 7,
    },
    new {
        Id = 4,
        Name = "Dermocosméticos",
        CategoryId = 9,
    },
    new {
        Id = 5,
        Name = "Preventivos",
        CategoryId = 11,
    },
    new {
        Id = 6,
        Name = "Talcos",
        CategoryId = 14,
    },
    new {
        Id = 7, 
        Name = "Vitaminas",
        CategoryId = 11
    },
    new {
        Id = 8,
        Name = "Dolor y Malestar",
        CategoryId = 3,
    },
    new {
        Id = 9,
        Name = "Congestión Nasal",
        CategoryId = 7
    },
    new {
        Id = 10,
        Name = "Otros Materiales",
        CategoryId = 17
    },
    new {
        Id = 11,
        Name = "Antiácidos",
        CategoryId = 3,
    },
    new {
        Id = 12,
        Name = "Condones",
        CategoryId = 20
    },
    new {
        Id = 13,
        Name = "Gotas para los ojos",
        CategoryId = 21
    },
    new {
        Id = 14,
        Name = "Accesorios cuidado de pies",
        CategoryId = 14,
    },
    new {
        Id = 15,
        Name = "Suplementos Nutricionales",
        CategoryId = 11
    },
    new {
        Id = 16,
        Name = "Equipos y Accesorios",
        CategoryId = 23
    },
    new {
        Id = 17,
        Name = "Musculares e Inflamación",
        CategoryId = 4
    },
    new {
        Id = 18, Name = "Embarazo",
        CategoryId = 11
    },
    new {
        Id = 19,
        Name = "Aceites y Cremas",
        CategoryId = 9
    },
    new {
        Id = 20,
        Name = "Gasas y Vendas",
        CategoryId = 17
    },
    new {
        Id = 21,
        Name = "Para Cuidado Bucal",
        CategoryId = 9
    },
    new {
        Id = 22,
        Name = "Tos",
        CategoryId = 7
    },
    new {
        Id = 23,
        Name = "Alergias",
        CategoryId = 7
    },
    new {
        Id = 24,
        Name = "Oídos",
        CategoryId = 21
    },
    new {
        Id = 25,
        Name = "Suplementos",
        CategoryId = 20
    },
    new {
        Id = 26,
        Name = "Guantes y Cubrebocas",
        CategoryId = 17
    },
    new {
        Id = 27,
        Name = "Antiparasitarios",
        CategoryId = 3
    },
    new {
        Id = 28,
        Name = "Antidiarreicos",
        CategoryId = 3
    },
    new {
        Id = 29,
        Name = "Alta Especialidad",
        CategoryId = 26
    },
    new {
        Id = 30,
        Name = "Anticonceptivos",
        CategoryId = 20
    },
    new {
        Id = 31,
        Name = "Antiacné PX",
        CategoryId = 9
    },
    new {
        Id = 32,
        Name = "Antiulcerantes",
        CategoryId = 3
    },
    new {
        Id = 33,
        Name = "Antimicóticos Pies",
        CategoryId = 14
    },
    new {
        Id = 34,
        Name = "Multivitamínicos",
        CategoryId = 11
    },
    new {
        Id = 35,
        Name = "Probióticos",
        CategoryId = 3
       
    },
    new {
        Id = 36,
        Name = "Banditas y telas adhesivas",
        CategoryId = 17
    },
    new {
        Id = 37,
        Name = "Laxante",
        CategoryId = 3
    },
    new {
        Id = 38,
        Name = "Tratamiento Diabetes",
        CategoryId = 23
       
    },
    new {
        Id = 39,
        Name = "Calcio",
        CategoryId = 6
    });
    }
}