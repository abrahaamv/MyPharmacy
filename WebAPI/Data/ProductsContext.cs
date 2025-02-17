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
        new
        {
            Id = 1,
            Name = "DISFAVIL"
        },
        new
        {
            Id = 2,
            Name = "ZUUM"
        },
        new
        {
            Id = 3,
            Name = "ENSURE"
        },
        new
        {
            Id = 4,
            Name = "SUPERIOR"
        },
        new
        {
            Id = 5,
            Name = "ALKA-SELTZER"
        },
        new
        {
            Id = 6,
            Name = "ALKOH"
        },
        new
        {
            Id = 7,
            Name = "SAL ANDREWS"
        },
        new
        {
            Id = 8,
            Name = "HIDRAVIDA"
        },
        new
        {
            Id = 9,
            Name = "MK"
        },
        new
        {
            Id = 10,
            Name = "VESA"
        },
        new
        {
            Id = 11,
            Name = "PANADOL"
        },
        new
        {
            Id = 12,
            Name = "GENESIS"
        },
        new
        {
            Id = 13,
            Name = "CERAVE"
        },
        new
        {
            Id = 14,
            Name = "VITAFLENACO"
        },
        new
        {
            Id = 15,
            Name = "TUMS"
        },
        new
        {
            Id = 16,
            Name = "CASTILLA"
        },
        new
        {
            Id = 17,
            Name = "ALKA EXTREME"
        },
        new
        {
            Id = 18,
            Name = "HANSAPLAST"
        },
        new
        {
            Id = 19,
            Name = "PEDIASURE"
        },
        new
        {
            Id = 20,
            Name = "ATLEVIT"
        },
        new
        {
            Id = 21,
            Name = "TYLENOL"
        },
        new
        {
            Id = 22,
            Name = "EXCELLENT"
        },
        new
        {
            Id = 23,
            Name = "DEOPIES"
        },
        new
        {
            Id = 24,
            Name = "GLUCERNA"
        },
        new
        {
            Id = 25,
            Name = "ASPIRINA"
        },
        new
        {
            Id = 26,
            Name = "METAMUCIL"
        },
        new
        {
            Id = 27,
            Name = "EUCERIN"
        },
        new
        {
            Id = 28,
            Name = "SANTA FE NATURA"
        },
        new
        {
            Id = 29,
            Name = "TABCIN"
        },
        new
        {
            Id = 30,
            Name = "GATORADE"
        },
        new
        {
            Id = 31,
            Name = "DORIVAL"
        },
        new
        {
            Id = 32,
            Name = "AFFECTIVE"
        },
        new
        {
            Id = 33,
            Name = "ADVIL"
        },
        new
        {
            Id = 34,
            Name = "VIJOSA"
        },
        new
        {
            Id = 35,
            Name = "SIETE MARES"
        },
        new
        {
            Id = 36,
            Name = "VIROGRIP"
        },
        new
        {
            Id = 37,
            Name = "VICK"
        },
        new
        {
            Id = 38,
            Name = "VICK VAPORUB"
        },
        new
        {
            Id = 39,
            Name = "LA BONNE VIE"
        },
        new
        {
            Id = 40,
            Name = "ALKA AD"
        },
        new
        {
            Id = 41,
            Name = "DUREX"
        },
        new
        {
            Id = 42,
            Name = "DRIVE MEDICAL"
        },
        new
        {
            Id = 43,
            Name = "PRUDENCE"
        },
        new
        {
            Id = 44,
            Name = "SAVORÂ"
        },
        new
        {
            Id = 45,
            Name = "PASINERVA"
        },
        new
        {
            Id = 46,
            Name = "INFASA"
        },
        new
        {
            Id = 47,
            Name = "QUALIPHARM"
        },
        new
        {
            Id = 48,
            Name = "PEPTO BISMOL"
        },
        new
        {
            Id = 49,
            Name = "PEDEX"
        },
        new
        {
            Id = 50,
            Name = "GELA-KIN"
        },
        new
        {
            Id = 51,
            Name = "VITABIOTICS"
        },
        new
        {
            Id = 52,
            Name = "BENET"
        },
        new
        {
            Id = 53,
            Name = "ENTEREX"
        },
        new
        {
            Id = 54,
            Name = "MASCARA"
        },
        new
        {
            Id = 55,
            Name = "VIVE"
        },
        new
        {
            Id = 56,
            Name = "CUREBAND"
        },
        new
        {
            Id = 57,
            Name = "GOOD BRANDS"
        },
        new
        {
            Id = 58,
            Name = "MEDIMART"
        },
        new
        {
            Id = 59,
            Name = "OMRON"
        },
        new
        {
            Id = 60,
            Name = "BEPANTHENE"
        },
        new
        {
            Id = 61,
            Name = "MEDIHEALTH"
        },
        new
        {
            Id = 62,
            Name = "VITAL FUERTE"
        },
        new
        {
            Id = 63,
            Name = "JOHNSON & JOHNSON"
        },
        new
        {
            Id = 64,
            Name = "MEDIPRODUCTS"
        },
        new
        {
            Id = 65,
            Name = "CENTRUM"
        },
        new
        {
            Id = 66,
            Name = "NEXCARE"
        },
        new
        {
            Id = 67,
            Name = "LA ROCHE-POSAY"
        },
        new
        {
            Id = 68,
            Name = "CAPLIN POINT LABORAT"
        },
        new
        {
            Id = 69,
            Name = "FRYCIA"
        },
        new
        {
            Id = 70,
            Name = "ALEVE"
        },
        new
        {
            Id = 71,
            Name = "BEBERÂ"
        },
        new
        {
            Id = 72,
            Name = "PIEX"
        },
        new
        {
            Id = 73,
            Name = "AMBIDERM"
        },
        new
        {
            Id = 74,
            Name = "ROEMMERS"
        },
        new
        {
            Id = 75,
            Name = "GUTIS"
        },
        new
        {
            Id = 76,
            Name = "CANESTEN"
        },
        new
        {
            Id = 77,
            Name = "DONOVAN"
        },
        new
        {
            Id = 78,
            Name = "FARMANDINA"
        },
        new
        {
            Id = 79,
            Name = "ISDIN"
        },
        new
        {
            Id = 80,
            Name = "DEL PILAR"
        },
        new
        {
            Id = 81,
            Name = "NUTRAMEDIX"
        },
        new
        {
            Id = 82,
            Name = "ALCON"
        },
        new
        {
            Id = 83,
            Name = "UNESIA"
        },
        new
        {
            Id = 84,
            Name = "NEXT-TABS"
        },
        new
        {
            Id = 85,
            Name = "GRIIN"
        },
        new
        {
            Id = 86,
            Name = "CEBION"
        },
        new
        {
            Id = 87,
            Name = "NEUMONIL"
        },
        new
        {
            Id = 88,
            Name = "COFAL"
        },
        new
        {
            Id = 89,
            Name = "CHEMILCO"
        },
        new
        {
            Id = 90,
            Name = "K-Y GEL"
        },
        new
        {
            Id = 91,
            Name = "REDOXITOS"
        },
        new
        {
            Id = 92,
            Name = "ALKA  GASTRIC"
        },
        new
        {
            Id = 93,
            Name = "VISINA"
        },
        new
        {
            Id = 94,
            Name = "NIPRO"
        },
        new
        {
            Id = 95,
            Name = "BAYER"
        },
        new
        {
            Id = 96,
            Name = "REDOXON"
        },
        new
        {
            Id = 97,
            Name = "BALLENA AZUL"
        },
        new
        {
            Id = 98,
            Name = "FERRER"
        },
        new
        {
            Id = 99,
            Name = "SIN MARCA"
        },
        new
        {
            Id = 100,
            Name = "CARDIOASPIRINA"
        },
        new
        {
            Id = 101,
            Name = "GMS"
        },
        new
        {
            Id = 102,
            Name = "PROCTER & GAMBLE"
        },
        new
        {
            Id = 103,
            Name = "PEDIALYTE"
        },
        new
        {
            Id = 104,
            Name = "VICHY"
        },
        new
        {
            Id = 105,
            Name = "B&J"
        },
        new
        {
            Id = 106,
            Name = "EXELTIS"
        },
        new
        {
            Id = 107,
            Name = "SUKROL"
        },
        new
        {
            Id = 108,
            Name = "FARKOT"
        },
        new
        {
            Id = 109,
            Name = "ANCALMO"
        },
        new
        {
            Id = 110,
            Name = "MENARINI"
        },
        new
        {
            Id = 111,
            Name = "LEMON GRASS"
        },
        new
        {
            Id = 112,
            Name = "GLAXOSMITHKLINE"
        },
        new
        {
            Id = 113,
            Name = "RENU"
        },
        new
        {
            Id = 114,
            Name = "ABL PHARMA"
        },
        new
        {
            Id = 115,
            Name = "VITAMIN SHOPPE"
        },
        new
        {
            Id = 116,
            Name = "SCOTT"
        },
        new
        {
            Id = 117,
            Name = "GNC"
        },
        new
        {
            Id = 118,
            Name = "BABARIA"
        },
        new
        {
            Id = 119,
            Name = "ASOFARMA"
        },
        new
        {
            Id = 120,
            Name = "GHL INTERNACION"
        },
        new
        {
            Id = 121,
            Name = "CHINOIN"
        },
        new
        {
            Id = 122,
            Name = "NEUROFORTAN"
        },
        new
        {
            Id = 123,
            Name = "PINGUINO"
        },
        new
        {
            Id = 124,
            Name = "ISIS PHARMA"
        },
        new
        {
            Id = 125,
            Name = "SANTA FE"
        },
        new
        {
            Id = 126,
            Name = "LANCASCO"
        },
        new
        {
            Id = 127,
            Name = "JALOMA"
        },
        new
        {
            Id = 128,
            Name = "CARDIO VITAL"
        },
        new
        {
            Id = 129,
            Name = "BMA PHARMA"
        },
        new
        {
            Id = 130,
            Name = "ABBOTT CFR"
        },
        new
        {
            Id = 131,
            Name = "DOLOKALORUB"
        },
        new
        {
            Id = 132,
            Name = "HIMALAYA"
        },
        new
        {
            Id = 133,
            Name = "DIQUIVA"
        },
        new
        {
            Id = 134,
            Name = "LAINEZ"
        },
        new
        {
            Id = 135,
            Name = "RUSSELL STOVER"
        },
        new
        {
            Id = 136,
            Name = "BAYKID"
        },
        new
        {
            Id = 137,
            Name = "BIODERMA"
        },
        new
        {
            Id = 138,
            Name = "GASTRO-BISMOL"
        },
        new
        {
            Id = 139,
            Name = "CIRUELAX"
        },
        new
        {
            Id = 140,
            Name = "BABE"
        },
        new
        {
            Id = 141,
            Name = "CICATRICURE"
        },
        new
        {
            Id = 142,
            Name = "ACIERTO"
        },
        new
        {
            Id = 143,
            Name = "VIZCAINO"
        },
        new
        {
            Id = 144,
            Name = "PRUMISA"
        },
        new
        {
            Id = 145,
            Name = "NIKZON"
        },
        new
        {
            Id = 146,
            Name = "LEONFLAX"
        },
        new
        {
            Id = 147,
            Name = "SANOFI CHC"
        },
        new
        {
            Id = 148,
            Name = "BONIN"
        },
        new
        {
            Id = 149,
            Name = "MERCK"
        },
        new
        {
            Id = 150,
            Name = "GENERIX"
        },
        new
        {
            Id = 151,
            Name = "UNIPHARM"
        },
        new
        {
            Id = 152,
            Name = "DENK"
        },
        new
        {
            Id = 153,
            Name = "VERDE VITA"
        },
        new
        {
            Id = 154,
            Name = "GUASURE"
        },
        new
        {
            Id = 155,
            Name = "QUIFARMA"
        },
        new
        {
            Id = 156,
            Name = "PROCAPS"
        },
        new
        {
            Id = 157,
            Name = "PIERSAN"
        },
        new
        {
            Id = 158,
            Name = "ICN GROSMAN"
        },
        new
        {
            Id = 159,
            Name = "ZEPOL"
        },
        new
        {
            Id = 160,
            Name = "MED PHARMA"
        },
        new
        {
            Id = 161,
            Name = "SEBAPHARMA"
        },
        new
        {
            Id = 162,
            Name = "VITAGEL"
        },
        new
        {
            Id = 163,
            Name = "BUSSIE"
        },
        new
        {
            Id = 164,
            Name = "PROFOOT"
        },
        new
        {
            Id = 165,
            Name = "FUTURO"
        },
        new
        {
            Id = 166,
            Name = "FARMAMEDICA"
        },
        new
        {
            Id = 167,
            Name = "QUINFICA"
        },
        new
        {
            Id = 168,
            Name = "BAYER  HEALTHCARE P"
        },
        new
        {
            Id = 169,
            Name = "JANSSEN"
        },
        new
        {
            Id = 170,
            Name = "ACON"
        },
        new
        {
            Id = 171,
            Name = "COREGA"
        },
        new
        {
            Id = 172,
            Name = "BIOCLEAN"
        },
        new
        {
            Id = 173,
            Name = "VIFOR"
        },
        new
        {
            Id = 174,
            Name = "GLOBAL FARMA"
        },
        new
        {
            Id = 175,
            Name = "CHURCH&DWIGHT"
        },
        new
        {
            Id = 176,
            Name = "PROTEINOL"
        },
        new
        {
            Id = 177,
            Name = "ROCHE"
        },
        new
        {
            Id = 178,
            Name = "LAFAGE"
        },
        new
        {
            Id = 179,
            Name = "DAVIS LAB."
        },
        new
        {
            Id = 180,
            Name = "LEUKOPLAST"
        },
        new
        {
            Id = 181,
            Name = "BIO TRUE"
        },
        new
        {
            Id = 182,
            Name = "ROWA WAGNER"
        },
        new
        {
            Id = 183,
            Name = "BIOTA"
        },
        new
        {
            Id = 184,
            Name = "FERRIDOCE"
        },
        new
        {
            Id = 185,
            Name = "ASTRA ZENECA"
        },
        new
        {
            Id = 186,
            Name = "LAXMI PHARMAC."
        },
        new
        {
            Id = 187,
            Name = "BALIARDA"
        },
        new
        {
            Id = 188,
            Name = "ALFER"
        },
        new
        {
            Id = 189,
            Name = "ROWE"
        },
        new
        {
            Id = 190,
            Name = "ESCUDO"
        },
        new
        {
            Id = 191,
            Name = "TERAMED"
        },
        new
        {
            Id = 192,
            Name = "VOLTAREN NOVARTIS"
        },
        new
        {
            Id = 193,
            Name = "LUNDBECK"
        },
        new
        {
            Id = 194,
            Name = "NUTRISON"
        },
        new
        {
            Id = 195,
            Name = "PHARMALAT"
        },
        new
        {
            Id = 196,
            Name = "ORGANON"
        },
        new
        {
            Id = 197,
            Name = "PAILL"
        },
        new
        {
            Id = 198,
            Name = "BOEHRINGER INGELHEIM"
        },
        new
        {
            Id = 199,
            Name = "MERCK SHARP & D"
        },
        new
        {
            Id = 200,
            Name = "ACINO PHARMA"
        },
        new
        {
            Id = 201,
            Name = "BIO-OIL"
        },
        new
        {
            Id = 202,
            Name = "LANSIER"
        },
        new
        {
            Id = 203,
            Name = "VIU"
        },
        new
        {
            Id = 204,
            Name = "ABBOTT LAB."
        },
        new
        {
            Id = 205,
            Name = "GLAXO PHARMA"
        },
        new
        {
            Id = 206,
            Name = "OSHI"
        },
        new
        {
            Id = 207,
            Name = "ALDO UNION"
        },
        new
        {
            Id = 208,
            Name = "GEX"
        },
        new
        {
            Id = 209,
            Name = "MEFASA"
        },
        new
        {
            Id = 210,
            Name = "BENESSI"
        },
        new
        {
            Id = 211,
            Name = "SERVIER"
        },
        new
        {
            Id = 212,
            Name = "PFIZER"
        },
        new
        {
            Id = 213,
            Name = "EXELTIS NOVARTIS"
        },
        new
        {
            Id = 214,
            Name = "BIOGAIA"
        },
        new
        {
            Id = 215,
            Name = "PHARBEST"
        },
        new
        {
            Id = 216,
            Name = "HIDRATOMIC"
        },
        new
        {
            Id = 217,
            Name = "ACCU-ANSWER"
        },
        new
        {
            Id = 218,
            Name = "NOVARTIS-COHEN"
        },
        new
        {
            Id = 219,
            Name = "SAVAL"
        },
        new
        {
            Id = 220,
            Name = "CHOLSAMAJ"
        },
        new
        {
            Id = 221,
            Name = "GARDEN HOUSE"
        },
        new
        {
            Id = 222,
            Name = "IPROFASA"
        },
        new
        {
            Id = 223,
            Name = "MILAGRO DE LA SELVA"
        },
        new
        {
            Id = 224,
            Name = "BENESTAR"
        },
        new
        {
            Id = 225,
            Name = "GRUPO FARMA"
        },
        new
        {
            Id = 226,
            Name = "SESDERMA S.A"
        },
        new
        {
            Id = 227,
            Name = "HARRY POTTER"
        },
        new
        {
            Id = 228,
            Name = "CRAYOLA SILLY SCENTS"
        },
        new
        {
            Id = 229,
            Name = "BONLIFE"
        },
        new
        {
            Id = 230,
            Name = "BENADRYL"
        },
        new
        {
            Id = 231,
            Name = "CHALVER"
        },
        new
        {
            Id = 232,
            Name = "CHILE"
        },
        new
        {
            Id = 233,
            Name = "ODDENT"
        },
        new
        {
            Id = 234,
            Name = "QG5"
        },
        new
        {
            Id = 235,
            Name = "SOPHIA"
        },
        new
        {
            Id = 236,
            Name = "HEIDELG"
        },
        new
        {
            Id = 237,
            Name = "ROHAPHARMA"
        },
        new
        {
            Id = 238,
            Name = "MEDITEMP"
        },
        new
        {
            Id = 239,
            Name = "INTECFA"
        },
        new
        {
            Id = 240,
            Name = "HIDRISAGE"
        },
        new
        {
            Id = 241,
            Name = "ELI LILLY"
        },
        new
        {
            Id = 242,
            Name = "KRAL"
        },
        new
        {
            Id = 243,
            Name = "MEGALABS"
        },
        new
        {
            Id = 244,
            Name = "ROTTA"
        },
        new
        {
            Id = 245,
            Name = "TOP MODEL"
        },
        new
        {
            Id = 246,
            Name = "NOVARTIS PHARMA"
        },
        new
        {
            Id = 247,
            Name = "BAYER HEALTHCARE P"
        },
        new
        {
            Id = 248,
            Name = "OFTISOL"
        },
        new
        {
            Id = 249,
            Name = "PHARMAKON"
        },
        new
        {
            Id = 250,
            Name = "GRUNENTHAL"
        },
        new
        {
            Id = 251,
            Name = "QUIMIFAR"
        },
        new
        {
            Id = 252,
            Name = "SAFEGUARD"
        },
        new
        {
            Id = 253,
            Name = "EUROFARMA"
        },
        new
        {
            Id = 254,
            Name = "BIOCODEX"
        },
        new
        {
            Id = 255,
            Name = "ARSAL"
        },
        new
        {
            Id = 256,
            Name = "PANALAB"
        },
        new
        {
            Id = 257,
            Name = "PHISA"
        },
        new
        {
            Id = 258,
            Name = "LEVEN"
        },
        new
        {
            Id = 259,
            Name = "MICROLIFE"
        },
        new
        {
            Id = 260,
            Name = "ASPEN"
        },
        new
        {
            Id = 261,
            Name = "LUVECK"
        },
        new
        {
            Id = 262,
            Name = "NOVARTIS"
        },
        new
        {
            Id = 263,
            Name = "EISAI"
        },
        new
        {
            Id = 264,
            Name = "LABORATORIOS MIDI"
        },
        new
        {
            Id = 265,
            Name = "WELLCO"
        },
        new
        {
            Id = 266,
            Name = "SANAMIEL"
        },
        new
        {
            Id = 267,
            Name = "SILANES"
        },
        new
        {
            Id = 268,
            Name = "SANOFI"
        },
        new
        {
            Id = 269,
            Name = "MERZ"
        },
        new
        {
            Id = 270,
            Name = "CHEMINTER"
        },
        new
        {
            Id = 271,
            Name = "PRODES"
        },
        new
        {
            Id = 272,
            Name = "ALLERGAN"
        },
        new
        {
            Id = 273,
            Name = "BAGO"
        },
        new
        {
            Id = 274,
            Name = "JR PHARMA"
        },
        new
        {
            Id = 275,
            Name = "RUBIOS"
        },
        new
        {
            Id = 276,
            Name = "BEBES LLORONES"
        },
        new
        {
            Id = 277,
            Name = "SANOFI-ETICO"
        },
        new
        {
            Id = 278,
            Name = "SAN GERMAN"
        },
        new
        {
            Id = 279,
            Name = "PHILLIPS"
        },
        new
        {
            Id = 280,
            Name = "MEMBER'S MARK"
        },
        new
        {
            Id = 281,
            Name = "DOGMA"
        },
        new
        {
            Id = 282,
            Name = "CUMLAUDE LAB"
        },
        new
        {
            Id = 283,
            Name = "ROSCOE"
        },
        new
        {
            Id = 284,
            Name = "DRIVE DEVILBISS HEALTHCARE"
        },
        new
        {
            Id = 285,
            Name = "GRISI"
        },
        new
        {
            Id = 286,
            Name = "BOSTON"
        },
        new
        {
            Id = 287,
            Name = "EQUATE"
        },
        new
        {
            Id = 288,
            Name = "OM"
        },
        new
        {
            Id = 289,
            Name = "SANDOZ"
        },
        new
        {
            Id = 290,
            Name = "NIELSEN BAINBRIDGE"
        },
        new
        {
            Id = 291,
            Name = "FAES"
        },
        new
        {
            Id = 292,
            Name = "PROTEC"
        },
        new
        {
            Id = 293,
            Name = "ANGELINI"
        });

        modelBuilder.Entity<Category>().HasData(
        new
        {
            Id = 1,
            Name = "Sistema digestivo y Antiparasitarios"
        },
        new
        {
            Id = 2,
            Name = "OTC"
        },
        new
        {
            Id = 3,
            Name = "Dolor e inflamación"
        },
        new
        {
            Id = 4,
            Name = "Analgésicos"
        },
        new
        {
            Id = 5,
            Name = "Estomacales"
        },
        new
        {
            Id = 6,
            Name = "Respiratorios"
        },
        new
        {
            Id = 7,
            Name = "Dermatología"
        },
        new
        {
            Id = 8,
            Name = "Multivitamínicos, Suplementos & Sistema Óseo"
        },
        new
        {
            Id = 9,
            Name = "Cuidado Personal"
        },
        new
        {
            Id = 10,
            Name = "Antiviral, gripe y tos"
        },
        new
        {
            Id = 11,
            Name = "Vitaminas y Suplementos"
        },
        new
        {
            Id = 12,
            Name = "Bienestar Sexual"
        },
        new
        {
            Id = 13,
            Name = "Cuidado de los Pies"
        },
        new
        {
            Id = 14,
            Name = "Bienestar, equipo médico y soluciones hospitalarias"
        },
        new
        {
            Id = 15,
            Name = "Anticonceptivos, hormonal y salud sexual"
        },
        new
        {
            Id = 16,
            Name = "Asma, alergias y nasal"
        },
        new
        {
            Id = 17,
            Name = "Material de Curación"
        },
        new
        {
            Id = 18,
            Name = "Cardiovascular & Hipertensivo"
        },
        new
        {
            Id = 19,
            Name = "Antimicótico"
        },
        new
        {
            Id = 20,
            Name = "Sistema Nervioso"
        },
        new
        {
            Id = 21,
            Name = "Salud Bucal, Oftalmológico & Oído"
        },
        new
        {
            Id = 22,
            Name = "Oftálmicos y Óticos"
        },
        new
        {
            Id = 23,
            Name = "Diabetes"
        },
        new
        {
            Id = 24,
            Name = "Diabetes y tiroides"
        },
        new
        {
            Id = 25,
            Name = "Medicamentos de Alta Especialidad"
        },
        new
        {
            Id = 26,
            Name = "Embarazo & lactancia infantil"
        },
        new
        {
            Id = 27,
            Name = "Sistema Urinario"
        },
        new
        {
            Id = 28,
            Name = "Colesterol y Triglicérido"
        },
        new
        {
            Id = 29,
            Name = "Antibiótico"
        });

        modelBuilder.Entity<SubCategory>().HasData(
        new
        {
            Id = 1,
            CategoryId = 4,
            Name = "Dolor"
        },
        new
        {
            Id = 2,
            CategoryId = 5,
            Name = "Sueros"
        },
        new
        {
            Id = 3,
            CategoryId = 6,
            Name = "Resfríos"
        },
        new
        {
            Id = 4,
            CategoryId = 9,
            Name = "Dermocosméticos"
        },
        new
        {
            Id = 5,
            CategoryId = 11,
            Name = "Preventivos"
        },
        new
        {
            Id = 6,
            CategoryId = 12,
            Name = "Condones"
        },
        new
        {
            Id = 7,
            CategoryId = 13,
            Name = "Talcos"
        },
        new
        {
            Id = 8,
            CategoryId = 17,
            Name = "Hisopos"
        },
        new
        {
            Id = 9,
            CategoryId = 17,
            Name = "Otros Materiales"
        },
        new
        {
            Id = 10,
            CategoryId = 11,
            Name = "Vitaminas"
        },
        new
        {
            Id = 11,
            CategoryId = 6,
            Name = "Congestión Nasal"
        },
        new
        {
            Id = 12,
            CategoryId = 5,
            Name = "Dolor y Malestar"
        },
        new
        {
            Id = 13,
            CategoryId = 17,
            Name = "Guantes y Cubrebocas"
        },
        new
        {
            Id = 14,
            CategoryId = 5,
            Name = "Antiácidos"
        },
        new
        {
            Id = 15,
            CategoryId = 13,
            Name = "Accesorios cuidado de pies"
        },
        new
        {
            Id = 16,
            CategoryId = 11,
            Name = "Suplementos Nutricionales"
        },
        new
        {
            Id = 17,
            CategoryId = 22,
            Name = "Gotas para los ojos"
        },
        new
        {
            Id = 18,
            CategoryId = 23,
            Name = "Equipos y Accesorios"
        },
        new
        {
            Id = 19,
            CategoryId = 13,
            Name = "Antimicóticos Pies"
        },
        new
        {
            Id = 20,
            CategoryId = 4,
            Name = "Musculares e Inflamación"
        },
        new
        {
            Id = 21,
            CategoryId = 11,
            Name = "Vitaminas y Suplementos/Calcio / Embarazo"
        },
        new
        {
            Id = 22,
            CategoryId = 6,
            Name = "Tos"
        },
        new
        {
            Id = 23,
            CategoryId = 9,
            Name = "Aceites y Cremas"
        },
        new
        {
            Id = 24,
            CategoryId = 6,
            Name = "Alergias"
        },
        new
        {
            Id = 25,
            CategoryId = 22,
            Name = "Oídos"
        },
        new
        {
            Id = 26,
            CategoryId = 17,
            Name = "Banditas y telas adhesivas"
        },
        new
        {
            Id = 27,
            CategoryId = 17,
            Name = "Gasas y Vendas"
        },
        new
        {
            Id = 28,
            CategoryId = 5,
            Name = "Antiparasitarios"
        },
        new
        {
            Id = 29,
            CategoryId = 25,
            Name = "Alta Especialidad"
        },
        new
        {
            Id = 30,
            CategoryId = 9,
            Name = "Para Cuidado Bucal"
        },
        new
        {
            Id = 31,
            CategoryId = 12,
            Name = "Anticonceptivos"
        },
        new
        {
            Id = 32,
            CategoryId = 23,
            Name = "Tratamiento Diabetes"
        },
        new
        {
            Id = 33,
            CategoryId = 9,
            Name = "Antiacné PX"
        },
        new
        {
            Id = 34,
            CategoryId = 11,
            Name = "Multivitamínicos"
        },
        new
        {
            Id = 35,
            CategoryId = 5,
            Name = "Antiulcerantes"
        },
        new
        {
            Id = 36,
            CategoryId = 5,
            Name = "Probióticos"
        },
        new
        {
            Id = 37,
            CategoryId = 5,
            Name = "Antidiarreicos"
        },
        new
        {
            Id = 38,
            CategoryId = 12,
            Name = "Suplementos"
        },
        new
        {
            Id = 39,
            CategoryId = 5,
            Name = "Laxante"
        });
    }
}