   M S B A M L   `   `   `  ����V  RSouliereTrehou_parisSportif, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SouliereTrehou_parisSportifSouliereTrehou_parisSportif  5   	   .    (SouliereTrehou_parisSportif.ParisSportif   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:SouliereTrehou_parisSportif     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	     � 
ResizeMode$  NoResize=�5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Paris Sportif��5   	   $	��750��6   $
��1250��6,   .��5      � 
���   � � RowDefinitions 5   
   �� 5      $��0.10* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��0.45* �6   .+�5   
   �� $��0��6   $��0��6"   $��2��62   ���#1e1e1e �� Orientation$ 
Horizontal=�6[   .+�5      o� $
��Left=�6   $��Center=�6.   .@�5      m� -   5        $��MenuItemHome��5   /   $��0,0,75,0q�6C   ��5       �� 5!      $ 
Horizontal=�6%     MenuItemSet#���  6>   .+�5"      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
DnsOutline=�66     LogoApp#��[ 6H   �� 5#      $��Bet1Max��6(     
MenuItemTb#���  67   5$      5&      m� 5'      -   5        $��MenuItemMatchs��5'   /   ��5(      �� 5)      $ 
Horizontal=�6%   #���  6>   .+�5*        $ Soccer=�66     
LogoHeader#��[ 6D   �� 5+      $��Football��6(   #���  68   5,      5.      m� 5/      -   5        $��MenuItemAdmin��5/   /   $y�Visible=�6D   ��50      �� 51      $ 
Horizontal=�6%   #���  6>   .+�52        $ Administrator=�66   #��[ 6K   �� 53      $��Administrator��6(   #���  6=   54      56      57      58      �� 59   
   $��1��6   $��0��6%   $��Center=�62   $ 
Horizontal=�6M   $��Right=�6f   $��0,0,20,0q�6�   .+�5:      �� $ 
Horizontal=�6   #���  62   .+�5;        $ AccountBalance=�6*   #��[ 6@   �� 5<      -   5        $��
TB_Balance��5<      #���  6.   5=      o� 5>      .@�5?      m� -   5        $��MenuItemUser��5?      $��Right=�6/   $��10q�6K   ��5@      �� 5A      $ 
Horizontal=�6%   #���  6>   .+�5B        $
 User=�66   #��[ 6B   �� 5C      -   5        $��	TB_Pseudo��5C   (   #���  69   5D      .@�5F      m� -   5        $��MenuItemMyData��5F   S   $��Voir mes informations��6   6S   m� 5G      -   5        $��MenuItemMyBets��5G   F   $��	Mes paris��6   6F   5H      5I      �� 5J      -	   5        $��35��5K      $��35��5L      $��Right=�5M        MaterialDesignIconButton#��[ 5N       ( $MaterialDesignTextFieldBoxBackground#���  5O       � Cursor$
 Hand��6Y   .��5P        $ Close=�6*   5Q      5R      � 5S   
   -
   5        	 �Name$	 	Container��5S      $��1��6"   $��2��6/   $��0��6C   5U      5W      5Y      