import json
import logging
import requests
from time import sleep

# Configure logging
logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')

# Constants
BRANDS = [
           {
             "Id": 1,
             "Name": "DISFAVIL"
           },
           {
             "Id": 2,
             "Name": "ZUUM"
           },
           {
             "Id": 3,
             "Name": "ENSURE"
           },
           {
             "Id": 4,
             "Name": "ALKOH"
           },
           {
             "Id": 5,
             "Name": "VESA"
           },
           {
             "Id": 6,
             "Name": "SUPERIOR"
           },
           {
             "Id": 7,
             "Name": "SAL ANDREWS"
           },
           {
             "Id": 8,
             "Name": "ALKA-SELTZER"
           },
           {
             "Id": 9,
             "Name": "HIDRAVIDA"
           },
           {
             "Id": 10,
             "Name": "PANADOL"
           },
           {
             "Id": 11,
             "Name": "MK"
           },
           {
             "Id": 12,
             "Name": "GLUCERNA"
           },
           {
             "Id": 13,
             "Name": "CASTILLA"
           },
           {
             "Id": 14,
             "Name": "GENESIS"
           },
           {
             "Id": 15,
             "Name": "VITAFLENACO"
           },
           {
             "Id": 16,
             "Name": "CERAVE"
           },
           {
             "Id": 17,
             "Name": "ATLEVIT"
           },
           {
             "Id": 18,
             "Name": "HANSAPLAST"
           },
           {
             "Id": 19,
             "Name": "ALKA EXTREME"
           },
           {
             "Id": 20,
             "Name": "TUMS"
           },
           {
             "Id": 21,
             "Name": "SANTA FE NATURA"
           },
           {
             "Id": 22,
             "Name": "EUCERIN"
           },
           {
             "Id": 23,
             "Name": "EXCELLENT"
           },
           {
             "Id": 24,
             "Name": "TYLENOL"
           },
           {
             "Id": 25,
             "Name": "PEDIASURE"
           },
           {
             "Id": 26,
             "Name": "DEOPIES"
           },
           {
             "Id": 27,
             "Name": "TABCIN"
           },
           {
             "Id": 28,
             "Name": "AFFECTIVE"
           },
           {
             "Id": 29,
             "Name": "ADVIL"
           },
           {
             "Id": 30,
             "Name": "GATORADE"
           },
           {
             "Id": 31,
             "Name": "DORIVAL"
           },
           {
             "Id": 32,
             "Name": "METAMUCIL"
           },
           {
             "Id": 33,
             "Name": "ASPIRINA"
           },
           {
             "Id": 34,
             "Name": "VIROGRIP"
           },
           {
             "Id": 35,
             "Name": "SAVORÂ"
           },
           {
             "Id": 36,
             "Name": "VIJOSA"
           },
           {
             "Id": 37,
             "Name": "GELA-KIN"
           },
           {
             "Id": 38,
             "Name": "PEDEX"
           },
           {
             "Id": 39,
             "Name": "INFASA"
           },
           {
             "Id": 40,
             "Name": "SIETE MARES"
           },
           {
             "Id": 41,
             "Name": "VICK"
           },
           {
             "Id": 42,
             "Name": "VICK VAPORUB"
           },
           {
             "Id": 43,
             "Name": "LA BONNE VIE"
           },
           {
             "Id": 44,
             "Name": "DRIVE MEDICAL"
           },
           {
             "Id": 45,
             "Name": "FARMANDINA"
           },
           {
             "Id": 46,
             "Name": "MEDIMART"
           },
           {
             "Id": 47,
             "Name": "PRUDENCE"
           },
           {
             "Id": 48,
             "Name": "QUALIPHARM"
           },
           {
             "Id": 49,
             "Name": "ALKA AD"
           },
           {
             "Id": 50,
             "Name": "JOHNSON & JOHNSON"
           },
           {
             "Id": 51,
             "Name": "PEPTO BISMOL"
           },
           {
             "Id": 52,
             "Name": "PASINERVA"
           },
           {
             "Id": 53,
             "Name": "VITABIOTICS"
           },
           {
             "Id": 54,
             "Name": "BENET"
           },
           {
             "Id": 55,
             "Name": "BEPANTHENE"
           },
           {
             "Id": 56,
             "Name": "BAYER"
           },
           {
             "Id": 57,
             "Name": "CUREBAND"
           },
           {
             "Id": 58,
             "Name": "PIEX"
           },
           {
             "Id": 59,
             "Name": "CENTRUM"
           },
           {
             "Id": 60,
             "Name": "GOOD BRANDS"
           },
           {
             "Id": 61,
             "Name": "DEL PILAR"
           },
           {
             "Id": 62,
             "Name": "NEXCARE"
           },
           {
             "Id": 63,
             "Name": "LA ROCHE-POSAY"
           },
           {
             "Id": 64,
             "Name": "ENTEREX"
           },
           {
             "Id": 65,
             "Name": "MASCARA"
           },
           {
             "Id": 66,
             "Name": "REDOXITOS"
           },
           {
             "Id": 67,
             "Name": "OMRON"
           },
           {
             "Id": 68,
             "Name": "DUREX"
           },
           {
             "Id": 69,
             "Name": "AMBIDERM"
           },
           {
             "Id": 70,
             "Name": "DONOVAN"
           },
           {
             "Id": 71,
             "Name": "GUTIS"
           },
           {
             "Id": 72,
             "Name": "CANESTEN"
           },
           {
             "Id": 73,
             "Name": "VIVE"
           },
           {
             "Id": 74,
             "Name": "SUKROL"
           },
           {
             "Id": 75,
             "Name": "BEBERÂ"
           },
           {
             "Id": 76,
             "Name": "NEXT-TABS"
           },
           {
             "Id": 77,
             "Name": "ALKA  GASTRIC"
           },
           {
             "Id": 78,
             "Name": "ROEMMERS"
           },
           {
             "Id": 79,
             "Name": "MEDIHEALTH"
           },
           {
             "Id": 80,
             "Name": "MENARINI"
           },
           {
             "Id": 81,
             "Name": "REDOXON"
           },
           {
             "Id": 82,
             "Name": "CAPLIN POINT LABORAT"
           },
           {
             "Id": 83,
             "Name": "UNESIA"
           },
           {
             "Id": 84,
             "Name": "CEBION"
           },
           {
             "Id": 85,
             "Name": "RENU"
           },
           {
             "Id": 86,
             "Name": "MEDIPRODUCTS"
           },
           {
             "Id": 87,
             "Name": "NEUMONIL"
           },
           {
             "Id": 88,
             "Name": "VISINA"
           },
           {
             "Id": 89,
             "Name": "NIPRO"
           },
           {
             "Id": 90,
             "Name": "ALDO UNION"
           },
           {
             "Id": 91,
             "Name": "FARKOT"
           },
           {
             "Id": 92,
             "Name": "ANCALMO"
           },
           {
             "Id": 93,
             "Name": "VITAL FUERTE"
           },
           {
             "Id": 94,
             "Name": "ALCON"
           },
           {
             "Id": 95,
             "Name": "CARDIOASPIRINA"
           },
           {
             "Id": 96,
             "Name": "DIQUIVA"
           },
           {
             "Id": 97,
             "Name": "ISDIN"
           },
           {
             "Id": 98,
             "Name": "NUTRAMEDIX"
           },
           {
             "Id": 99,
             "Name": "ALEVE"
           },
           {
             "Id": 100,
             "Name": "BALLENA AZUL"
           },
           {
             "Id": 101,
             "Name": "FRYCIA"
           },
           {
             "Id": 102,
             "Name": "ABL PHARMA"
           },
           {
             "Id": 103,
             "Name": "GRIIN"
           },
           {
             "Id": 104,
             "Name": "SIN MARCA"
           },
           {
             "Id": 105,
             "Name": "COFAL"
           },
           {
             "Id": 106,
             "Name": "B&J"
           },
           {
             "Id": 107,
             "Name": "VICHY"
           },
           {
             "Id": 108,
             "Name": "K-Y GEL"
           },
           {
             "Id": 109,
             "Name": "PEDIALYTE"
           },
           {
             "Id": 110,
             "Name": "NEUROFORTAN"
           },
           {
             "Id": 111,
             "Name": "BABE"
           },
           {
             "Id": 112,
             "Name": "CHINOIN"
           },
           {
             "Id": 113,
             "Name": "ABBOTT CFR"
           },
           {
             "Id": 114,
             "Name": "PIERSAN"
           },
           {
             "Id": 115,
             "Name": "MERCK"
           },
           {
             "Id": 116,
             "Name": "JALOMA"
           },
           {
             "Id": 117,
             "Name": "LEUKOPLAST"
           },
           {
             "Id": 118,
             "Name": "FERRER"
           },
           {
             "Id": 119,
             "Name": "DOLOKALORUB"
           },
           {
             "Id": 120,
             "Name": "BABARIA"
           },
           {
             "Id": 121,
             "Name": "GENERIX"
           },
           {
             "Id": 122,
             "Name": "ASOFARMA"
           },
           {
             "Id": 123,
             "Name": "QUINFICA"
           },
           {
             "Id": 124,
             "Name": "LEMON GRASS"
           },
           {
             "Id": 125,
             "Name": "BONIN"
           },
           {
             "Id": 126,
             "Name": "PROCTER & GAMBLE"
           },
           {
             "Id": 127,
             "Name": "SANOFI CHC"
           },
           {
             "Id": 128,
             "Name": "COREGA"
           },
           {
             "Id": 129,
             "Name": "ISIS PHARMA"
           },
           {
             "Id": 130,
             "Name": "UNIPHARM"
           },
           {
             "Id": 131,
             "Name": "SCOTT"
           },
           {
             "Id": 132,
             "Name": "GMS"
           },
           {
             "Id": 133,
             "Name": "VERDE VITA"
           },
           {
             "Id": 134,
             "Name": "CHEMILCO"
           },
           {
             "Id": 135,
             "Name": "QUIFARMA"
           },
           {
             "Id": 136,
             "Name": "VITAMIN SHOPPE"
           },
           {
             "Id": 137,
             "Name": "BMA PHARMA"
           },
           {
             "Id": 138,
             "Name": "ICN GROSMAN"
           },
           {
             "Id": 139,
             "Name": "EXELTIS"
           },
           {
             "Id": 140,
             "Name": "MED PHARMA"
           },
           {
             "Id": 141,
             "Name": "GEX"
           },
           {
             "Id": 142,
             "Name": "GASTRO-BISMOL"
           },
           {
             "Id": 143,
             "Name": "CIRUELAX"
           },
           {
             "Id": 144,
             "Name": "GNC"
           },
           {
             "Id": 145,
             "Name": "BAYKID"
           },
           {
             "Id": 146,
             "Name": "ACIERTO"
           },
           {
             "Id": 147,
             "Name": "HIMALAYA"
           },
           {
             "Id": 148,
             "Name": "LEONFLAX"
           },
           {
             "Id": 149,
             "Name": "PHILLIPS"
           },
           {
             "Id": 150,
             "Name": "RUSSELL STOVER"
           },
           {
             "Id": 151,
             "Name": "ACON"
           },
           {
             "Id": 152,
             "Name": "GLAXOSMITHKLINE"
           },
           {
             "Id": 153,
             "Name": "PROTEINOL"
           },
           {
             "Id": 154,
             "Name": "SANTA FE"
           },
           {
             "Id": 155,
             "Name": "CARDIO VITAL"
           },
           {
             "Id": 156,
             "Name": "DENK"
           },
           {
             "Id": 157,
             "Name": "LANCASCO"
           },
           {
             "Id": 158,
             "Name": "BENADRYL"
           },
           {
             "Id": 159,
             "Name": "LAXMI PHARMAC."
           },
           {
             "Id": 160,
             "Name": "VIZCAINO"
           },
           {
             "Id": 161,
             "Name": "LAINEZ"
           },
           {
             "Id": 162,
             "Name": "ZEPOL"
           },
           {
             "Id": 163,
             "Name": "BUSSIE"
           },
           {
             "Id": 164,
             "Name": "BIODERMA"
           },
           {
             "Id": 165,
             "Name": "SEBAPHARMA"
           },
           {
             "Id": 166,
             "Name": "MEFASA"
           },
           {
             "Id": 167,
             "Name": "PROFOOT"
           },
           {
             "Id": 168,
             "Name": "GHL INTERNACION"
           },
           {
             "Id": 169,
             "Name": "BAYER  HEALTHCARE P"
           },
           {
              "Id": 169,
              "Name": "BAYER HEALTHCARE P"
           },
           {
             "Id": 170,
             "Name": "SAFEGUARD"
           },
           {
             "Id": 171,
             "Name": "JANSSEN"
           },
           {
             "Id": 172,
             "Name": "CHOLSAMAJ"
           },
           {
             "Id": 173,
             "Name": "PINGUINO"
           },
           {
             "Id": 174,
             "Name": "NIKZON"
           },
           {
             "Id": 175,
             "Name": "ROCHE"
           },
           {
             "Id": 176,
             "Name": "PRUMISA"
           },
           {
             "Id": 177,
             "Name": "ABBOTT LAB."
           },
           {
             "Id": 178,
             "Name": "GUASURE"
           },
           {
             "Id": 179,
             "Name": "GRUPO FARMA"
           },
           {
             "Id": 180,
             "Name": "ROWE"
           },
           {
             "Id": 181,
             "Name": "BOEHRINGER INGELHEIM"
           },
           {
             "Id": 182,
             "Name": "GLOBAL FARMA"
           },
           {
             "Id": 183,
             "Name": "ACCU-ANSWER"
           },
           {
             "Id": 184,
             "Name": "BIOCLEAN"
           },
           {
             "Id": 185,
             "Name": "LAFAGE"
           },
           {
             "Id": 186,
             "Name": "DAVIS LAB."
           },
           {
             "Id": 187,
             "Name": "ODDENT"
           },
           {
             "Id": 188,
             "Name": "CHURCH&DWIGHT"
           },
           {
             "Id": 189,
             "Name": "PROCAPS"
           },
           {
             "Id": 190,
             "Name": "FERRIDOCE"
           },
           {
             "Id": 191,
             "Name": "HEIDELG"
           },
           {
             "Id": 192,
             "Name": "ROWA WAGNER"
           },
           {
             "Id": 193,
             "Name": "ALFER"
           },
           {
             "Id": 194,
             "Name": "PHARMALAT"
           },
           {
             "Id": 195,
             "Name": "ASTRA ZENECA"
           },
           {
             "Id": 196,
             "Name": "EUROFARMA"
           },
           {
             "Id": 197,
             "Name": "PAILL"
           },
           {
             "Id": 198,
             "Name": "BIO TRUE"
           },
           {
             "Id": 199,
             "Name": "LABORATORIOS MIDI"
           },
           {
             "Id": 200,
             "Name": "TERAMED"
           },
           {
             "Id": 201,
             "Name": "LUNDBECK"
           },
           {
             "Id": 202,
             "Name": "ORGANON"
           },
           {
             "Id": 203,
             "Name": "ACINO PHARMA"
           },
           {
             "Id": 204,
             "Name": "ESCUDO"
           },
           {
             "Id": 205,
             "Name": "NUTRISON"
           },
           {
             "Id": 206,
             "Name": "NOVARTIS PHARMA"
           },
           {
             "Id": 207,
             "Name": "GLAXO PHARMA"
           },
           {
             "Id": 208,
             "Name": "PFIZER"
           },
           {
             "Id": 209,
             "Name": "VIU"
           },
           {
             "Id": 210,
             "Name": "BENESTAR"
           },
           {
             "Id": 211,
             "Name": "BENESSI"
           },
           {
             "Id": 212,
             "Name": "CRAYOLA SILLY SCENTS"
           },
           {
             "Id": 213,
             "Name": "EXELTIS NOVARTIS"
           },
           {
             "Id": 214,
             "Name": "HIDRATOMIC"
           },
           {
             "Id": 215,
             "Name": "SERVIER"
           },
           {
             "Id": 216,
             "Name": "PHARBEST"
           },
           {
             "Id": 217,
             "Name": "VITAGEL"
           },
           {
             "Id": 218,
             "Name": "OSHI"
           },
           {
             "Id": 219,
             "Name": "MERZ"
           },
           {
             "Id": 220,
             "Name": "CHEMINTER"
           },
           {
             "Id": 221,
             "Name": "SANOFI"
           },
           {
             "Id": 222,
             "Name": "FARMAMEDICA"
           },
           {
             "Id": 223,
             "Name": "FUTURO"
           },
           {
             "Id": 224,
             "Name": "GARDEN HOUSE"
           },
           {
             "Id": 225,
             "Name": "NOVARTIS-COHEN"
           },
           {
             "Id": 226,
             "Name": "DRIVE DEVILBISS HEALTHCARE"
           },
           {
             "Id": 227,
             "Name": "SAVAL"
           },
           {
             "Id": 228,
             "Name": "VIFOR"
           },
           {
             "Id": 229,
             "Name": "IPROFASA"
           },
           {
             "Id": 230,
             "Name": "BONLIFE"
           },
           {
             "Id": 231,
             "Name": "MILAGRO DE LA SELVA"
           },
           {
             "Id": 232,
             "Name": "OM"
           },
           {
             "Id": 233,
             "Name": "HARRY POTTER"
           },
           {
             "Id": 234,
             "Name": "MEDITEMP"
           },
           {
             "Id": 235,
             "Name": "PANALAB"
           },
           {
             "Id": 236,
             "Name": "CHALVER"
           },
           {
             "Id": 237,
             "Name": "KRAL"
           },
           {
             "Id": 238,
             "Name": "CHILE"
           },
           {
             "Id": 239,
             "Name": "QG5"
           },
           {
             "Id": 240,
             "Name": "SESDERMA S.A"
           },
           {
             "Id": 241,
             "Name": "GRUNENTHAL"
           },
           {
             "Id": 242,
             "Name": "HIDRISAGE"
           },
           {
             "Id": 243,
             "Name": "INTECFA"
           },
           {
             "Id": 244,
             "Name": "ROHAPHARMA"
           },
           {
             "Id": 245,
             "Name": "EISAI"
           },
           {
             "Id": 246,
             "Name": "ROTTA"
           },
           {
             "Id": 247,
             "Name": "MERCK SHARP & D"
           },
           {
             "Id": 248,
             "Name": "QUIMIFAR"
           },
           {
             "Id": 249,
             "Name": "ASPEN"
           },
           {
             "Id": 250,
             "Name": "ARSAL"
           },
           {
             "Id": 251,
             "Name": "BIOTA"
           },
           {
             "Id": 252,
             "Name": "PHARMAKON"
           },
           {
             "Id": 253,
             "Name": "ANGELINI"
           },
           {
             "Id": 254,
             "Name": "OFTISOL"
           },
           {
             "Id": 255,
             "Name": "PHISA"
           },
           {
             "Id": 256,
             "Name": "SANDOZ"
           },
           {
             "Id": 257,
             "Name": "LEVEN"
           },
           {
             "Id": 258,
             "Name": "NOVARTIS"
           },
           {
             "Id": 259,
             "Name": "BALIARDA"
           },
           {
             "Id": 260,
             "Name": "SILANES"
           },
           {
             "Id": 261,
             "Name": "SOPHIA"
           },
           {
             "Id": 262,
             "Name": "BIOCODEX"
           },
           {
             "Id": 263,
             "Name": "LANSIER"
           },
           {
             "Id": 264,
             "Name": "MEGALABS"
           },
           {
             "Id": 265,
             "Name": "PROTEC"
           },
           {
             "Id": 266,
             "Name": "WELLCO"
           },
           {
             "Id": 267,
             "Name": "LUVECK"
           },
           {
             "Id": 268,
             "Name": "MICROLIFE"
           },
           {
             "Id": 269,
             "Name": "TOP MODEL"
           },
           {
             "Id": 270,
             "Name": "ELI LILLY"
           },
           {
             "Id": 271,
             "Name": "JR PHARMA"
           },
           {
             "Id": 272,
             "Name": "PRODES"
           },
           {
             "Id": 273,
             "Name": "ALLERGAN"
           },
           {
             "Id": 274,
             "Name": "BAGO"
           },
           {
             "Id": 275,
             "Name": "SANAMIEL"
           },
           {
             "Id": 276,
             "Name": "BEBES LLORONES"
           },
           {
             "Id": 277,
             "Name": "RUBIOS"
           },
           {
             "Id": 278,
             "Name": "SANOFI-ETICO"
           },
           {
             "Id": 279,
             "Name": "SAN GERMAN"
           },
           {
             "Id": 280,
             "Name": "MEMBER'S MARK"
           },
           {
             "Id": 281,
             "Name": "ROSCOE"
           },
           {
             "Id": 282,
             "Name": "GRISI"
           },
           {
             "Id": 283,
             "Name": "GENFAR"
           },
           {
             "Id": 284,
             "Name": "CUMLAUDE LAB"
           },
           {
             "Id": 285,
             "Name": "EQUATE"
           },
           {
             "Id": 286,
             "Name": "BOSTON"
           },
           {
             "Id": 287,
             "Name": "NIELSEN BAINBRIDGE"
           }
         ]
         
CATEGORIES = [
               {
                 "Id": 1,
                 "Name": "Sistema digestivo y Antiparasitarios"
               },
               {
                 "Id": 2,
                 "Name": "OTC"
               },
               {
                 "Id": 3,
                 "Name": "Estomacales"
               },
               {
                 "Id": 4,
                 "Name": "Analgésicos"
               },
               {
                 "Id": 5,
                 "Name": "Dolor e inflamación"
               },
               {
                 "Id": 6,
                 "Name": "Multivitamínicos, Suplementos & Sistema Óseo"
               },
               {
                 "Id": 7,
                 "Name": "Respiratorios"
               },
               {
                 "Id": 8,
                 "Name": "Dermatología"
               },
               {
                 "Id": 9,
                 "Name": "Cuidado Personal"
               },
               {
                 "Id": 10,
                 "Name": "Antiviral, gripe y tos"
               },
               {
                 "Id": 11,
                 "Name": "Vitaminas y Suplementos"
               },
               {
                 "Id": 12,
                 "Name": "Asma, alergias y nasal"
               },
               {
                 "Id": 13,
                 "Name": "Bienestar, equipo médico y soluciones hospitalarias"
               },
               {
                 "Id": 14,
                 "Name": "Cuidado de los Pies"
               },
               {
                 "Id": 15,
                 "Name": "Anticonceptivos, hormonal y salud sexual"
               },
               {
                 "Id": 16,
                 "Name": "Cardiovascular & Hipertensivo"
               },
               {
                 "Id": 17,
                 "Name": "Material de Curación"
               },
               {
                 "Id": 18,
                 "Name": "Antimicótico"
               },
               {
                 "Id": 19,
                 "Name": "Sistema Nervioso"
               },
               {
                 "Id": 20,
                 "Name": "Bienestar Sexual"
               },
               {
                 "Id": 21,
                 "Name": "Oftálmicos y Óticos"
               },
               {
                 "Id": 22,
                 "Name": "Salud Bucal, Oftalmológico & Oído"
               },
               {
                 "Id": 23,
                 "Name": "Diabetes"
               },
               {
                 "Id": 24,
                 "Name": "Diabetes y tiroides"
               },
               {
                 "Id": 25,
                 "Name": "Embarazo & lactancia infantil"
               },
               {
                 "Id": 26,
                 "Name": "Medicamentos de Alta Especialidad"
               },
               {
                 "Id": 27,
                 "Name": "Colesterol y Triglicérido"
               },
               {
                 "Id": 28,
                 "Name": "Sistema Urinario"
               },
               {
                 "Id": 29,
                 "Name": "Antibiótico"
               }
             ]
SUBCATEGORIES = [
                  {
                    "Id": 1,
                    "Name": "Sueros"
                  },
                  {
                    "Id": 2,
                    "Name": "Dolor"
                  },
                  {
                    "Id": 3,
                    "Name": "Resfríos"
                  },
                  {
                    "Id": 4,
                    "Name": "Dermocosméticos"
                  },
                  {
                    "Id": 5,
                    "Name": "Preventivos"
                  },
                  {
                    "Id": 6,
                    "Name": "Talcos"
                  },
                  {
                    "Id": 7,
                    "Name": "Vitaminas"
                  },
                  {
                    "Id": 8,
                    "Name": "Dolor y Malestar"
                  },
                  {
                    "Id": 9,
                    "Name": "Congestión Nasal"
                  },
                  {
                    "Id": 10,
                    "Name": "Otros Materiales"
                  },
                  {
                    "Id": 11,
                    "Name": "Antiácidos"
                  },
                  {
                    "Id": 12,
                    "Name": "Condones"
                  },
                  {
                    "Id": 13,
                    "Name": "Gotas para los ojos"
                  },
                  {
                    "Id": 14,
                    "Name": "Accesorios cuidado de pies"
                  },
                  {
                    "Id": 15,
                    "Name": "Suplementos Nutricionales"
                  },
                  {
                    "Id": 16,
                    "Name": "Equipos y Accesorios"
                  },
                  {
                    "Id": 17,
                    "Name": "Musculares e Inflamación"
                  },
                  {
                    "Id": 18,
                    "Name": "Embarazo"
                  },
                  {
                    "Id": 19,
                    "Name": "Aceites y Cremas"
                  },
                  {
                    "Id": 20,
                    "Name": "Gasas y Vendas"
                  },
                  {
                    "Id": 21,
                    "Name": "Para Cuidado Bucal"
                  },
                  {
                    "Id": 22,
                    "Name": "Tos"
                  },
                  {
                    "Id": 23,
                    "Name": "Alergias"
                  },
                  {
                    "Id": 24,
                    "Name": "Oídos"
                  },
                  {
                    "Id": 25,
                    "Name": "Suplementos"
                  },
                  {
                    "Id": 26,
                    "Name": "Guantes y Cubrebocas"
                  },
                  {
                    "Id": 27,
                    "Name": "Antiparasitarios"
                  },
                  {
                    "Id": 28,
                    "Name": "Antidiarreicos"
                  },
                  {
                    "Id": 29,
                    "Name": "Alta Especialidad"
                  },
                  {
                    "Id": 30,
                    "Name": "Anticonceptivos"
                  },
                  {
                    "Id": 31,
                    "Name": "Antiacné PX"
                  },
                  {
                    "Id": 32,
                    "Name": "Antiulcerantes"
                  },
                  {
                    "Id": 33,
                    "Name": "Antimicóticos Pies"
                  },
                  {
                    "Id": 34,
                    "Name": "Multivitamínicos"
                  },
                  {
                    "Id": 35,
                    "Name": "Probióticos"
                  },
                  {
                    "Id": 36,
                    "Name": "Banditas y telas adhesivas"
                  },
                  {
                    "Id": 37,
                    "Name": "Laxante"
                  },
                  {
                    "Id": 38,
                    "Name": "Tratamiento Diabetes"
                  },
                  {
                    "Id": 39,
                    "Name": "Calcio "
                  }
                ]
                
API_URL = "http://localhost:5094/productos"
HEADERS = {"Content-Type": "application/json"}

# Helper functions
def map_category(categories):
    """Maps category and subcategory from the path."""
    first_category = categories[0].strip('/') if categories else None
    if first_category:
        parts = first_category.split('/')
        if len(parts) > 1:
            category_name = parts[1]
            subcategory_name = parts[2] if len(parts) > 2 else None
        else:
            category_name = parts[0]
            subcategory_name = None

        category = next((c for c in CATEGORIES if c['Name'] == category_name), None)
        subcategory = next((s for s in SUBCATEGORIES if subcategory_name and s['Name'] == subcategory_name), None)

        if not category:
            logging.warning(f"Category name not found: {category_name}")
        if subcategory_name and not subcategory:
            logging.warning(f"Subcategory name not found: {subcategory_name}")

        return category['Id'] if category else None, subcategory['Id'] if subcategory_name and subcategory else None
    return None, None

def map_brand(brand_name):
    """Maps brand to its ID."""
    brand = next((b for b in BRANDS if b['Name'] == brand_name), None)
    if not brand:
        logging.warning(f"Brand name not found: {brand_name}")
    return brand['Id'] if brand else None

def clean_image_url(url):
    """Removes query parameters from image URLs."""
    return url.split('?')[0]

# Load JSON data
with open('../SeedData/Products/products_data.json', 'r') as file:
    products = json.load(file)

# Process products
for product in products:
    try:
        # Map brand
        brand_id = map_brand(product['brand'])
        if not brand_id:
            logging.warning(f"Brand not found for product {product['id']}: {product['brand']}")
            continue

        # Map category and subcategory
        categories = [cat.strip('/') for cat in product['categories']]
        category_id, subcategory_id = map_category(categories)
        if not category_id:
            logging.warning(f"Category not found for product {product['id']}: {product['categories']}")
            continue

        # Prepare API payload
        payload = {
            "ean": product['id'],
            "name": product['Name'],
            "description": product['description'],
            "slug": product['slug'],
            "brandId": brand_id,
            "categoryId": category_id,
            "subcategoryId": subcategory_id,
            "listPrice": product['listPrice'],
            "sellingPrice": product['sellingPrice'],
            "stock": product['availableQuantity'],
            "imageUrls": [clean_image_url(image['imageUrl']) for image in product['images']],
            "specifications": [
                {
                    "name": spec['name'],
                    "value": spec['values'][0] if spec['values'] else None
                }
                for spec in product['especifications']
            ]
        }

        # Log payload
        #logging.info(f"Processing product {product['id']}: {payload}") // Full object log
        logging.info(f" ")

        # Make POST request
        response = requests.post(API_URL, headers=HEADERS, json=payload)
        if response.status_code == 201:
           # logging.info(f"Product {product['id']} created successfully.")
           logging.info(f"")
        else:
            logging.error(f"Failed to create product {product['id']}: {response.status_code}")
            break

        # Throttle requests to avoid overloading the server
        sleep(0.1)

    except Exception as e:
        logging.exception(f"An error occurred while processing product {product['id']}: {e}")
