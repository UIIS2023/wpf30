   M S B A M L   `   `   `  ����F  BWPFTERETANA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFTERETANAWPFTERETANA  5   	        WPFTERETANA.FrmReklamacija   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPFTERETANA     5   	     � Title$  Dodaj/Izmeni Reklamaciju��5   	   $	��270��6*   $	��300��67   .��5	      � .+�5
   
   �� $��ID Reklamacije:��6   $
��Left=�6*   $��	30,20,0,0q�6E   $	��Top=�6X   �� 5   
   $��Opis Reklamacije:��6   $
��Left=�6,   $��	30,50,0,0q�6G   $	��Top=�6Z   �� 5   
   $��ID Zaposlenog��6   $
��Left=�6(   $��	30,80,0,0q�6C   $	��Top=�6V   �� 5   
   -   5         ��Name$ txtReklamacijaID��5      $
��Left=�6,   $��23��6G   $��
130,20,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
30,194,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��175,194,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $ txtOpisReklamacije��5      $
��Left=�6.   $��23��6I   $��
130,51,0,0q�6U   $
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $	��120��6�   �� 5   
   $��ID Klijenta��6   $
��Left=�6&   $��
30,111,0,0q�6A   $	��Top=�6U   �� 5   
   -   5         ��Name$ cbIDZaposlenog��5      $
��Left=�6+   $��
131,81,0,0q�6F   $	��Top=�6Z   $	��120��6r    �� SelectedValuePath$ ZaposleniID��6~   �� 5   
   -   5        $ cbIDKlijenta��5      $
��Left=�6)   $��	131,0,0,0q�6D   $��Center=�6W   $	��120��6r   $ 	KlijentID��6~   5      5      