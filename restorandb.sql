PGDMP  -            
    
    |            restoranSiparisYonetim    15.8    16.4 `    s           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            t           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            u           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            v           1262    17129    restoranSiparisYonetim    DATABASE     �   CREATE DATABASE "restoranSiparisYonetim" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Turkish_T�rkiye.1254';
 (   DROP DATABASE "restoranSiparisYonetim";
                postgres    false            �            1259    17138    garson    TABLE     �   CREATE TABLE public.garson (
    garson_id integer NOT NULL,
    ad character varying(30) NOT NULL,
    soyad character varying(30) NOT NULL
);
    DROP TABLE public.garson;
       public         heap    postgres    false            �            1259    17137    garson_garson_id_seq    SEQUENCE     �   CREATE SEQUENCE public.garson_garson_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.garson_garson_id_seq;
       public          postgres    false    217            w           0    0    garson_garson_id_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.garson_garson_id_seq OWNED BY public.garson.garson_id;
          public          postgres    false    216            �            1259    17152    kasiyer    TABLE     �   CREATE TABLE public.kasiyer (
    kasiyer_id integer NOT NULL,
    ad character varying(30) NOT NULL,
    soyad character varying(30) NOT NULL
);
    DROP TABLE public.kasiyer;
       public         heap    postgres    false            �            1259    17151    kasiyer_kasiyer_id_seq    SEQUENCE     �   CREATE SEQUENCE public.kasiyer_kasiyer_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.kasiyer_kasiyer_id_seq;
       public          postgres    false    221            x           0    0    kasiyer_kasiyer_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.kasiyer_kasiyer_id_seq OWNED BY public.kasiyer.kasiyer_id;
          public          postgres    false    220            �            1259    17145    kategori    TABLE     s   CREATE TABLE public.kategori (
    kategori_id integer NOT NULL,
    kategoriadi character varying(20) NOT NULL
);
    DROP TABLE public.kategori;
       public         heap    postgres    false            �            1259    17144    kategori_kategori_id_seq    SEQUENCE     �   CREATE SEQUENCE public.kategori_kategori_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.kategori_kategori_id_seq;
       public          postgres    false    219            y           0    0    kategori_kategori_id_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public.kategori_kategori_id_seq OWNED BY public.kategori.kategori_id;
          public          postgres    false    218            �            1259    17166    masa    TABLE     ;   CREATE TABLE public.masa (
    masa_id integer NOT NULL
);
    DROP TABLE public.masa;
       public         heap    postgres    false            �            1259    17165    masa_masa_id_seq    SEQUENCE     �   CREATE SEQUENCE public.masa_masa_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.masa_masa_id_seq;
       public          postgres    false    225            z           0    0    masa_masa_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.masa_masa_id_seq OWNED BY public.masa.masa_id;
          public          postgres    false    224            �            1259    17159    musteri    TABLE     �   CREATE TABLE public.musteri (
    musteri_id integer NOT NULL,
    ad character varying(30) NOT NULL,
    soyad character varying(30) NOT NULL,
    telefon character varying(10)
);
    DROP TABLE public.musteri;
       public         heap    postgres    false            �            1259    17158    musteri_musteri_id_seq    SEQUENCE     �   CREATE SEQUENCE public.musteri_musteri_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.musteri_musteri_id_seq;
       public          postgres    false    223            {           0    0    musteri_musteri_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.musteri_musteri_id_seq OWNED BY public.musteri.musteri_id;
          public          postgres    false    222            �            1259    17131    mutfakpersoneli    TABLE     �   CREATE TABLE public.mutfakpersoneli (
    mutfakp_id integer NOT NULL,
    ad character varying(30) NOT NULL,
    soyad character varying(30) NOT NULL
);
 #   DROP TABLE public.mutfakpersoneli;
       public         heap    postgres    false            �            1259    17130    mutfakpersoneli_mutfakp_id_seq    SEQUENCE     �   CREATE SEQUENCE public.mutfakpersoneli_mutfakp_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 5   DROP SEQUENCE public.mutfakpersoneli_mutfakp_id_seq;
       public          postgres    false    215            |           0    0    mutfakpersoneli_mutfakp_id_seq    SEQUENCE OWNED BY     a   ALTER SEQUENCE public.mutfakpersoneli_mutfakp_id_seq OWNED BY public.mutfakpersoneli.mutfakp_id;
          public          postgres    false    214            �            1259    17225    odeme    TABLE     �   CREATE TABLE public.odeme (
    odeme_id integer NOT NULL,
    kasiyer_id integer,
    siparisid integer,
    tarih timestamp without time zone NOT NULL,
    odemeturu character varying(15),
    tutar numeric(8,2) NOT NULL
);
    DROP TABLE public.odeme;
       public         heap    postgres    false            �            1259    17224    odeme_odeme_id_seq    SEQUENCE     �   CREATE SEQUENCE public.odeme_odeme_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.odeme_odeme_id_seq;
       public          postgres    false    233            }           0    0    odeme_odeme_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.odeme_odeme_id_seq OWNED BY public.odeme.odeme_id;
          public          postgres    false    232            �            1259    17242    rezervasyon    TABLE     �  CREATE TABLE public.rezervasyon (
    rezervasyon_id integer NOT NULL,
    musteri_id integer,
    masa_id integer,
    rezervasyontarihi timestamp without time zone NOT NULL,
    kisisayisi integer NOT NULL,
    durum character varying(20) DEFAULT 'Bekliyor'::character varying,
    iptaltarihi timestamp without time zone,
    guncellenmetarihi timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);
    DROP TABLE public.rezervasyon;
       public         heap    postgres    false            �            1259    17241    rezervasyon_rezervasyon_id_seq    SEQUENCE     �   CREATE SEQUENCE public.rezervasyon_rezervasyon_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 5   DROP SEQUENCE public.rezervasyon_rezervasyon_id_seq;
       public          postgres    false    235            ~           0    0    rezervasyon_rezervasyon_id_seq    SEQUENCE OWNED BY     a   ALTER SEQUENCE public.rezervasyon_rezervasyon_id_seq OWNED BY public.rezervasyon.rezervasyon_id;
          public          postgres    false    234            �            1259    17197    siparis    TABLE     �   CREATE TABLE public.siparis (
    siparis_id integer NOT NULL,
    masa_id integer,
    musteri_id integer,
    mutfak_id integer,
    garson_id integer,
    durum character varying(25),
    toplamfiyat numeric(10,2)
);
    DROP TABLE public.siparis;
       public         heap    postgres    false            �            1259    17196    siparis_siparis_id_seq    SEQUENCE     �   CREATE SEQUENCE public.siparis_siparis_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.siparis_siparis_id_seq;
       public          postgres    false    231                       0    0    siparis_siparis_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.siparis_siparis_id_seq OWNED BY public.siparis.siparis_id;
          public          postgres    false    230            �            1259    17260    siparis_urun    TABLE     d   CREATE TABLE public.siparis_urun (
    siparis_id integer NOT NULL,
    urun_id integer NOT NULL
);
     DROP TABLE public.siparis_urun;
       public         heap    postgres    false            �            1259    17185    stok    TABLE     �   CREATE TABLE public.stok (
    stok_id integer NOT NULL,
    urun_id integer,
    stokdurum integer NOT NULL,
    guncellemetarih timestamp without time zone NOT NULL
);
    DROP TABLE public.stok;
       public         heap    postgres    false            �            1259    17184    stok_stok_id_seq    SEQUENCE     �   CREATE SEQUENCE public.stok_stok_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.stok_stok_id_seq;
       public          postgres    false    229            �           0    0    stok_stok_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.stok_stok_id_seq OWNED BY public.stok.stok_id;
          public          postgres    false    228            �            1259    17173    urunler    TABLE     �   CREATE TABLE public.urunler (
    urun_id integer NOT NULL,
    kategori_id integer,
    ad character varying(30) NOT NULL,
    stokdurum integer NOT NULL,
    fiyat numeric(6,2) NOT NULL
);
    DROP TABLE public.urunler;
       public         heap    postgres    false            �            1259    17172    urunler_urun_id_seq    SEQUENCE     �   CREATE SEQUENCE public.urunler_urun_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.urunler_urun_id_seq;
       public          postgres    false    227            �           0    0    urunler_urun_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.urunler_urun_id_seq OWNED BY public.urunler.urun_id;
          public          postgres    false    226            �           2604    17141    garson garson_id    DEFAULT     t   ALTER TABLE ONLY public.garson ALTER COLUMN garson_id SET DEFAULT nextval('public.garson_garson_id_seq'::regclass);
 ?   ALTER TABLE public.garson ALTER COLUMN garson_id DROP DEFAULT;
       public          postgres    false    216    217    217            �           2604    17155    kasiyer kasiyer_id    DEFAULT     x   ALTER TABLE ONLY public.kasiyer ALTER COLUMN kasiyer_id SET DEFAULT nextval('public.kasiyer_kasiyer_id_seq'::regclass);
 A   ALTER TABLE public.kasiyer ALTER COLUMN kasiyer_id DROP DEFAULT;
       public          postgres    false    220    221    221            �           2604    17148    kategori kategori_id    DEFAULT     |   ALTER TABLE ONLY public.kategori ALTER COLUMN kategori_id SET DEFAULT nextval('public.kategori_kategori_id_seq'::regclass);
 C   ALTER TABLE public.kategori ALTER COLUMN kategori_id DROP DEFAULT;
       public          postgres    false    218    219    219            �           2604    17169    masa masa_id    DEFAULT     l   ALTER TABLE ONLY public.masa ALTER COLUMN masa_id SET DEFAULT nextval('public.masa_masa_id_seq'::regclass);
 ;   ALTER TABLE public.masa ALTER COLUMN masa_id DROP DEFAULT;
       public          postgres    false    224    225    225            �           2604    17162    musteri musteri_id    DEFAULT     x   ALTER TABLE ONLY public.musteri ALTER COLUMN musteri_id SET DEFAULT nextval('public.musteri_musteri_id_seq'::regclass);
 A   ALTER TABLE public.musteri ALTER COLUMN musteri_id DROP DEFAULT;
       public          postgres    false    222    223    223            �           2604    17134    mutfakpersoneli mutfakp_id    DEFAULT     �   ALTER TABLE ONLY public.mutfakpersoneli ALTER COLUMN mutfakp_id SET DEFAULT nextval('public.mutfakpersoneli_mutfakp_id_seq'::regclass);
 I   ALTER TABLE public.mutfakpersoneli ALTER COLUMN mutfakp_id DROP DEFAULT;
       public          postgres    false    214    215    215            �           2604    17228    odeme odeme_id    DEFAULT     p   ALTER TABLE ONLY public.odeme ALTER COLUMN odeme_id SET DEFAULT nextval('public.odeme_odeme_id_seq'::regclass);
 =   ALTER TABLE public.odeme ALTER COLUMN odeme_id DROP DEFAULT;
       public          postgres    false    233    232    233            �           2604    17245    rezervasyon rezervasyon_id    DEFAULT     �   ALTER TABLE ONLY public.rezervasyon ALTER COLUMN rezervasyon_id SET DEFAULT nextval('public.rezervasyon_rezervasyon_id_seq'::regclass);
 I   ALTER TABLE public.rezervasyon ALTER COLUMN rezervasyon_id DROP DEFAULT;
       public          postgres    false    234    235    235            �           2604    17200    siparis siparis_id    DEFAULT     x   ALTER TABLE ONLY public.siparis ALTER COLUMN siparis_id SET DEFAULT nextval('public.siparis_siparis_id_seq'::regclass);
 A   ALTER TABLE public.siparis ALTER COLUMN siparis_id DROP DEFAULT;
       public          postgres    false    231    230    231            �           2604    17188    stok stok_id    DEFAULT     l   ALTER TABLE ONLY public.stok ALTER COLUMN stok_id SET DEFAULT nextval('public.stok_stok_id_seq'::regclass);
 ;   ALTER TABLE public.stok ALTER COLUMN stok_id DROP DEFAULT;
       public          postgres    false    228    229    229            �           2604    17176    urunler urun_id    DEFAULT     r   ALTER TABLE ONLY public.urunler ALTER COLUMN urun_id SET DEFAULT nextval('public.urunler_urun_id_seq'::regclass);
 >   ALTER TABLE public.urunler ALTER COLUMN urun_id DROP DEFAULT;
       public          postgres    false    226    227    227            ]          0    17138    garson 
   TABLE DATA           6   COPY public.garson (garson_id, ad, soyad) FROM stdin;
    public          postgres    false    217   �o       a          0    17152    kasiyer 
   TABLE DATA           8   COPY public.kasiyer (kasiyer_id, ad, soyad) FROM stdin;
    public          postgres    false    221   ap       _          0    17145    kategori 
   TABLE DATA           <   COPY public.kategori (kategori_id, kategoriadi) FROM stdin;
    public          postgres    false    219   �p       e          0    17166    masa 
   TABLE DATA           '   COPY public.masa (masa_id) FROM stdin;
    public          postgres    false    225   q       c          0    17159    musteri 
   TABLE DATA           A   COPY public.musteri (musteri_id, ad, soyad, telefon) FROM stdin;
    public          postgres    false    223   Bq       [          0    17131    mutfakpersoneli 
   TABLE DATA           @   COPY public.mutfakpersoneli (mutfakp_id, ad, soyad) FROM stdin;
    public          postgres    false    215   �q       m          0    17225    odeme 
   TABLE DATA           Y   COPY public.odeme (odeme_id, kasiyer_id, siparisid, tarih, odemeturu, tutar) FROM stdin;
    public          postgres    false    233   *r       o          0    17242    rezervasyon 
   TABLE DATA           �   COPY public.rezervasyon (rezervasyon_id, musteri_id, masa_id, rezervasyontarihi, kisisayisi, durum, iptaltarihi, guncellenmetarihi) FROM stdin;
    public          postgres    false    235   �r       k          0    17197    siparis 
   TABLE DATA           l   COPY public.siparis (siparis_id, masa_id, musteri_id, mutfak_id, garson_id, durum, toplamfiyat) FROM stdin;
    public          postgres    false    231    s       p          0    17260    siparis_urun 
   TABLE DATA           ;   COPY public.siparis_urun (siparis_id, urun_id) FROM stdin;
    public          postgres    false    236   �s       i          0    17185    stok 
   TABLE DATA           L   COPY public.stok (stok_id, urun_id, stokdurum, guncellemetarih) FROM stdin;
    public          postgres    false    229   �s       g          0    17173    urunler 
   TABLE DATA           M   COPY public.urunler (urun_id, kategori_id, ad, stokdurum, fiyat) FROM stdin;
    public          postgres    false    227   t       �           0    0    garson_garson_id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.garson_garson_id_seq', 10, true);
          public          postgres    false    216            �           0    0    kasiyer_kasiyer_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.kasiyer_kasiyer_id_seq', 10, true);
          public          postgres    false    220            �           0    0    kategori_kategori_id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.kategori_kategori_id_seq', 10, true);
          public          postgres    false    218            �           0    0    masa_masa_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.masa_masa_id_seq', 1, false);
          public          postgres    false    224            �           0    0    musteri_musteri_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.musteri_musteri_id_seq', 10, true);
          public          postgres    false    222            �           0    0    mutfakpersoneli_mutfakp_id_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('public.mutfakpersoneli_mutfakp_id_seq', 10, true);
          public          postgres    false    214            �           0    0    odeme_odeme_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.odeme_odeme_id_seq', 5, true);
          public          postgres    false    232            �           0    0    rezervasyon_rezervasyon_id_seq    SEQUENCE SET     L   SELECT pg_catalog.setval('public.rezervasyon_rezervasyon_id_seq', 5, true);
          public          postgres    false    234            �           0    0    siparis_siparis_id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public.siparis_siparis_id_seq', 5, true);
          public          postgres    false    230            �           0    0    stok_stok_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.stok_stok_id_seq', 5, true);
          public          postgres    false    228            �           0    0    urunler_urun_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.urunler_urun_id_seq', 5, true);
          public          postgres    false    226            �           2606    17143    garson garson_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public.garson
    ADD CONSTRAINT garson_pkey PRIMARY KEY (garson_id);
 <   ALTER TABLE ONLY public.garson DROP CONSTRAINT garson_pkey;
       public            postgres    false    217            �           2606    17157    kasiyer kasiyer_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.kasiyer
    ADD CONSTRAINT kasiyer_pkey PRIMARY KEY (kasiyer_id);
 >   ALTER TABLE ONLY public.kasiyer DROP CONSTRAINT kasiyer_pkey;
       public            postgres    false    221            �           2606    17150    kategori kategori_pkey 
   CONSTRAINT     ]   ALTER TABLE ONLY public.kategori
    ADD CONSTRAINT kategori_pkey PRIMARY KEY (kategori_id);
 @   ALTER TABLE ONLY public.kategori DROP CONSTRAINT kategori_pkey;
       public            postgres    false    219            �           2606    17171    masa masa_pkey 
   CONSTRAINT     Q   ALTER TABLE ONLY public.masa
    ADD CONSTRAINT masa_pkey PRIMARY KEY (masa_id);
 8   ALTER TABLE ONLY public.masa DROP CONSTRAINT masa_pkey;
       public            postgres    false    225            �           2606    17164    musteri musteri_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.musteri
    ADD CONSTRAINT musteri_pkey PRIMARY KEY (musteri_id);
 >   ALTER TABLE ONLY public.musteri DROP CONSTRAINT musteri_pkey;
       public            postgres    false    223            �           2606    17136 $   mutfakpersoneli mutfakpersoneli_pkey 
   CONSTRAINT     j   ALTER TABLE ONLY public.mutfakpersoneli
    ADD CONSTRAINT mutfakpersoneli_pkey PRIMARY KEY (mutfakp_id);
 N   ALTER TABLE ONLY public.mutfakpersoneli DROP CONSTRAINT mutfakpersoneli_pkey;
       public            postgres    false    215            �           2606    17230    odeme odeme_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.odeme
    ADD CONSTRAINT odeme_pkey PRIMARY KEY (odeme_id);
 :   ALTER TABLE ONLY public.odeme DROP CONSTRAINT odeme_pkey;
       public            postgres    false    233            �           2606    17249    rezervasyon rezervasyon_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.rezervasyon
    ADD CONSTRAINT rezervasyon_pkey PRIMARY KEY (rezervasyon_id);
 F   ALTER TABLE ONLY public.rezervasyon DROP CONSTRAINT rezervasyon_pkey;
       public            postgres    false    235            �           2606    17203    siparis siparis_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.siparis
    ADD CONSTRAINT siparis_pkey PRIMARY KEY (siparis_id);
 >   ALTER TABLE ONLY public.siparis DROP CONSTRAINT siparis_pkey;
       public            postgres    false    231            �           2606    17264    siparis_urun siparis_urun_pkey 
   CONSTRAINT     m   ALTER TABLE ONLY public.siparis_urun
    ADD CONSTRAINT siparis_urun_pkey PRIMARY KEY (siparis_id, urun_id);
 H   ALTER TABLE ONLY public.siparis_urun DROP CONSTRAINT siparis_urun_pkey;
       public            postgres    false    236    236            �           2606    17190    stok stok_pkey 
   CONSTRAINT     Q   ALTER TABLE ONLY public.stok
    ADD CONSTRAINT stok_pkey PRIMARY KEY (stok_id);
 8   ALTER TABLE ONLY public.stok DROP CONSTRAINT stok_pkey;
       public            postgres    false    229            �           2606    17178    urunler urunler_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public.urunler
    ADD CONSTRAINT urunler_pkey PRIMARY KEY (urun_id);
 >   ALTER TABLE ONLY public.urunler DROP CONSTRAINT urunler_pkey;
       public            postgres    false    227            �           2606    17231    odeme odeme_kasiyer_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.odeme
    ADD CONSTRAINT odeme_kasiyer_id_fkey FOREIGN KEY (kasiyer_id) REFERENCES public.kasiyer(kasiyer_id);
 E   ALTER TABLE ONLY public.odeme DROP CONSTRAINT odeme_kasiyer_id_fkey;
       public          postgres    false    221    233    3247            �           2606    17236    odeme odeme_siparisid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.odeme
    ADD CONSTRAINT odeme_siparisid_fkey FOREIGN KEY (siparisid) REFERENCES public.siparis(siparis_id);
 D   ALTER TABLE ONLY public.odeme DROP CONSTRAINT odeme_siparisid_fkey;
       public          postgres    false    231    3257    233            �           2606    17255 $   rezervasyon rezervasyon_masa_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.rezervasyon
    ADD CONSTRAINT rezervasyon_masa_id_fkey FOREIGN KEY (masa_id) REFERENCES public.masa(masa_id);
 N   ALTER TABLE ONLY public.rezervasyon DROP CONSTRAINT rezervasyon_masa_id_fkey;
       public          postgres    false    225    3251    235            �           2606    17250 '   rezervasyon rezervasyon_musteri_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.rezervasyon
    ADD CONSTRAINT rezervasyon_musteri_id_fkey FOREIGN KEY (musteri_id) REFERENCES public.musteri(musteri_id);
 Q   ALTER TABLE ONLY public.rezervasyon DROP CONSTRAINT rezervasyon_musteri_id_fkey;
       public          postgres    false    3249    235    223            �           2606    17219    siparis siparis_garson_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.siparis
    ADD CONSTRAINT siparis_garson_id_fkey FOREIGN KEY (garson_id) REFERENCES public.garson(garson_id);
 H   ALTER TABLE ONLY public.siparis DROP CONSTRAINT siparis_garson_id_fkey;
       public          postgres    false    3243    217    231            �           2606    17204    siparis siparis_masa_id_fkey    FK CONSTRAINT        ALTER TABLE ONLY public.siparis
    ADD CONSTRAINT siparis_masa_id_fkey FOREIGN KEY (masa_id) REFERENCES public.masa(masa_id);
 F   ALTER TABLE ONLY public.siparis DROP CONSTRAINT siparis_masa_id_fkey;
       public          postgres    false    231    225    3251            �           2606    17209    siparis siparis_musteriid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.siparis
    ADD CONSTRAINT siparis_musteriid_fkey FOREIGN KEY (musteri_id) REFERENCES public.musteri(musteri_id);
 H   ALTER TABLE ONLY public.siparis DROP CONSTRAINT siparis_musteriid_fkey;
       public          postgres    false    223    3249    231            �           2606    17214    siparis siparis_mutfak_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.siparis
    ADD CONSTRAINT siparis_mutfak_id_fkey FOREIGN KEY (mutfak_id) REFERENCES public.mutfakpersoneli(mutfakp_id);
 H   ALTER TABLE ONLY public.siparis DROP CONSTRAINT siparis_mutfak_id_fkey;
       public          postgres    false    231    215    3241            �           2606    17265 )   siparis_urun siparis_urun_siparis_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.siparis_urun
    ADD CONSTRAINT siparis_urun_siparis_id_fkey FOREIGN KEY (siparis_id) REFERENCES public.siparis(siparis_id);
 S   ALTER TABLE ONLY public.siparis_urun DROP CONSTRAINT siparis_urun_siparis_id_fkey;
       public          postgres    false    231    3257    236            �           2606    17270 &   siparis_urun siparis_urun_urun_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.siparis_urun
    ADD CONSTRAINT siparis_urun_urun_id_fkey FOREIGN KEY (urun_id) REFERENCES public.urunler(urun_id);
 P   ALTER TABLE ONLY public.siparis_urun DROP CONSTRAINT siparis_urun_urun_id_fkey;
       public          postgres    false    227    236    3253            �           2606    17191    stok stok_urun_id_fkey    FK CONSTRAINT     |   ALTER TABLE ONLY public.stok
    ADD CONSTRAINT stok_urun_id_fkey FOREIGN KEY (urun_id) REFERENCES public.urunler(urun_id);
 @   ALTER TABLE ONLY public.stok DROP CONSTRAINT stok_urun_id_fkey;
       public          postgres    false    3253    227    229            �           2606    17179     urunler urunler_kategori_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.urunler
    ADD CONSTRAINT urunler_kategori_id_fkey FOREIGN KEY (kategori_id) REFERENCES public.kategori(kategori_id);
 J   ALTER TABLE ONLY public.urunler DROP CONSTRAINT urunler_kategori_id_fkey;
       public          postgres    false    3245    219    227            ]   W   x�3�t�-J�<�1'7��ˈө�(1�ӱ2���<.cΨ�ʼ���ӪJ�)��2��M-*�h *��2�NMI���I,����� �\      a   U   x�3��NL��<<�*%57��ˈ�)�(�����".c��Ԝ�<���D.N�Ԣ�D����%�y\�����% �%��es��qqq 1E�      _   E   x�3�t�KT�L�M��2�I,�9��˘�Ȇ��S��b&���9�%�\��N�G��$��xx9W� �A�      e      x�3�2�2�2�2����� ��      c   v   x�3�tI�ˬ�<�1'7�����������̜ˈ�#1;1�ӱ2���<�D˘385'3��𴪔���"�Dʒ˄�5'3��;�($5�2��--J,�<ܞZ�	6"a����� ]=%      [   R   x�3�t��M-�<�1'7��ˈ�7,��X��e�阓�钚�Y�e��X���y�=5'3�˔ӱ���TN��{�Rs�b���� ���      m   b   x�]̱�0D�ڞ��L,+ 1MJD����Ӑ��ӁPS�� ��M���|_��&������S*Q�g�F��km*��Sߗ5d�H�+suFf~�$�      o   t   x�����0�s� �>�@�$$2��FƤF��h�e���X���Da`0.۾^�	���L������Zs� (�R�P�dAQ8%�҄A$�ܥ��&<D����v���E.      k   ]   x�3�4�B�Ī#�r�l��/�47�35�2�A4iKS=.#NJ&V&*8�٘�rd#���H�1'B��p� �FS��=... -      p   !   x�3�4�2�4�2�4�2�4�2�4����� '�      i   F   x�e���0k1Ep)�d��?G0%>}��"y�X�_��7&̩r��Yuh� �p�%�n>���6����      g   j   x�3�4��>�-�$��Ȁ��@�Ԁ�(�YU��ih�ij�g`�e�i�锘��X�T�id
4�4�<ܞX�ih`�	1�4��'%�)'�$�$UI��qqq �}�     