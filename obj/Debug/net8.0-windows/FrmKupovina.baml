   M S B A M L   `   `   `  ����F  BWPFTERETANA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFTERETANAWPFTERETANA  5   	       WPFTERETANA.FrmKupovina   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPFTERETANA     5   	     � Title$  Dodaj/Izmeni Kupovinu��5   	   $	��350��6'   $	��300��64   .��5	      � $��	0,0,1,-13q�6   .+�5
   
   �� $��ID Kupovine:��6   $
��Left=�6'   $��	31,10,0,0q�6B   $	��Top=�6U   �� 5   
   -   5         ��Name$ txtIDKupovine��5      $
��Left=�6)   $��23��6D   $��
125,13,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
24,310,0,0q�6R   $	��Top=�6f   $��75��6~    J� RenderTransformOrigin$ 0.498,2.783&�6�   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��168,310,0,0q�6P   $	��Top=�6e   $��75��6}   $ 
0.46,2.507&�6�   �� 5   
   $��Vrsta Kupovine:��6   $
��Left=�6*   $��	28,41,0,0q�6E   $	��Top=�6X   �� 5   
   $��Broj Racuna:��6   $
��Left=�6'   $��	31,70,0,0q�6B   $	��Top=�6U   �� 5   
   $��Popust:��6   $
��Left=�6"   $��	40,97,0,0q�6=   $	��Top=�6P   �� 5   
   -   5        $ txtVrstaKupovine��5      $
��Left=�6,   $��23��6G   $��
125,43,0,0q�6S   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtBrojRacuna��5      $
��Left=�6)   $��23��6D   $��
124,74,0,0q�6P   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   �� 5   
   $��Iznos Popusta:��6   $
��Left=�6)   $��
28,124,0,0q�6D   $	��Top=�6X   �� 5   
   $��Datum:��6   $
��Left=�6!   $��
33,163,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $ txtIznosPopusta��5      $
��Left=�6+   $��23��6F   $��121,131,0,0q�6R   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��120��6�   �� 5   
   $��ID Robe��6   $
��Left=�6"   $��
38,202,0,0q�6=   $	��Top=�6Q   $ 0.474,0.618&�6i   �� 5   
   $��ID Zaposlenog��6   $
��Left=�6(   $��
27,236,0,0q�6C   $	��Top=�6W   �� 5   
   -   5         ��Name$ cbIDRobe��5      $
��Left=�6%   $��127,204,0,0q�6@   $	��Top=�6U   $	��120��6m    �� SelectedValuePath$ RobaID��6y   �� 5   
   -   5        $ cbIDZaposlenog��5      $
��Left=�6+   $��125,238,0,0q�6F   $	��Top=�6[   $	��120��6s   $ ZaposleniID��6   �� 5   
   $��ID Klijenta��6   $
��Left=�6&   $��
34,264,0,0q�6A   $	��Top=�6U   �� 5   
   -	   5        $ cbIDKlijenta��5      $
��Left=�6)   $��124,267,0,0q�6D   $	��Top=�6Y   $	��120��6q   (  "System.Windows.Controls.DatePicker  5   
   -
   5          Name$ dtDatum��5      $
��Left=�6&   $��125,164,0,0q�6A   $	��Top=�6V   $	��122��6n   �� 5   
   -   5         ��Name$ 	cbxPopust��5      $��Popust��6&   $
��Left=�67   $��139,104,0,0q�6R   $	��Top=�6g   $	��121��6   $��23��6�   5      5       