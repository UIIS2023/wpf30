   M S B A M L   `   `   `  ����F  BWPFTERETANA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFTERETANAWPFTERETANA  5   	       WPFTERETANA.FrmGarancija   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPFTERETANA     5   	     � Title$  Dodaj/Izmeni Igru��5   	   $	��270��6#   $	��300��60   .��5	      � .+�5
   
   �� $��ID Garancije:��6   $
��Left=�6(   $��	30,20,0,0q�6C   $	��Top=�6V   �� 5   
   $��ID Zaposlenog:��6   $
��Left=�6)   $��	30,50,0,0q�6D   $	��Top=�6W   �� 5   
   $��ID Robe��6   $
��Left=�6"   $��	30,80,0,0q�6=   $	��Top=�6P   �� 5   
   -   5         ��Name$ txtGarancijaID��5      $
��Left=�6*   $��23��6E   $��
130,20,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtTrajanje��5      $
��Left=�6'   $��23��6B   $��129,112,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
30,194,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��175,194,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   $��Datum:��6   $
��Left=�6!   $��
30,142,0,0q�6<   $	��Top=�6P   �� 5   
   $��Trajanje��6   $
��Left=�6#   $��
30,111,0,0q�6>   $	��Top=�6R   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dtDatum��5      $
��Left=�6&   $��132,143,0,0q�6A   $	��Top=�6V   $	��115��6n   �� 5   
   -   5         ��Name$ cbIDZaposlenog��5      $
��Left=�6-   $��
129,51,0,0q�6H   $	��Top=�6\   $	��120��6t    �� SelectedValuePath$ ZaposleniID��6�   �� 5   
   -   5        $ cbIDRobe��5      $
��Left=�6'   $��
128,82,0,0q�6B   $	��Top=�6V   $	��120��6n   $ RobaID��6z   5      5      