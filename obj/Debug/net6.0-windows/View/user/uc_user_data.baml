   M S B A M L   `   `   `  ����V  RSouliereTrehou_parisSportif, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:SouliereTrehou_parisSportif.View.user%SouliereTrehou_parisSportif.View.user  5      8    2SouliereTrehou_parisSportif.View.user.uc_user_data   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Elocal3clr-namespace:SouliereTrehou_parisSportif.View.user     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	         MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � 
���   � � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��1��6   ���#1e1e1e$
��0,25q�64   .+�5      �� .+�5      �� $��25q�6   $��Mes informations��6(      MaterialDesignBody2TextBlock#���  6@   �� 5       �� Orientation$ 
Horizontal=�6   $��5q�66   .+�5      � $	��200��6   $	��200��6'   .+�5       �� -   5        $��TB_username��5    "   $��Center=�5!   "   $��10q�5"   "   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��5#   "    ! MaterialDesignOutlinedTextBox#��[ 5$   "   .��6Y   )  #MaterialDesignThemes.Wpf.HintAssist   Hint 5%      �� 5&   "   $ 
Horizontal=�6-   $��-2,0,0,0q�6F   .+�5'   &   �� $��username��60   5(   #   .��5)   >   5*      5+      �� 5,      -   5        $��bt_username��5,   2    � Cursor$
 Hand��6E   .��5-      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Edit=�62   5.      5/      �� 50      $ 
Horizontal=�6   $��5q�66   .+�51      � $	��200��6   $	��225��6'   .+�52      �� -   5        $��TB_email��52   "   $��Center=�53   "   $��10q�54   "   $
 True��55   "   #��[ 56   "   .��6Y    57      �� 58   "   $ 
Horizontal=�6-   $��-2,0,0,0q�6F   .+�59   &   �� $��email��60   5:   #   .��5;   >   5<      5=      �� 5>      -   5        $��bt_email��5>   2   .��5?        $
 Edit=�62   5@      5A      �� 5B      $ 
Horizontal=�6   $��5q�66   .+�5C      � $	��200��6   $	��225��6'   .+�5D      �� -   5        $��TB_Perm��5D   "   $��Center=�5E   "   $��10q�5F   "    �� 
IsReadOnly$
 True��5G   "   #��[ 5H   "   .��6Y    5I      �� 5J   "   $ 
Horizontal=�6-   $��-2,0,0,0q�6F   .+�5K   &   �� $
��Perm��60   5L   #   .��5M   >   5N      5O      5P      �� 5Q      $��3��6   $��1��6*   $ 
Horizontal=�6:   $��5q�6S   .+�5R      � $	��200��6   $	��225��6'   .+�5S      G� -   5        $��PB_Password��5U   &    + 'MaterialDesignOutlinedRevealPasswordBox#��[ 5S   &   $��10q�5T   &   $	��Top=�5V   &   $
 True��5W   &   {�5X   &   �� 	 �� Path$	 	IsChecked�
 �� ElementName$6
 0MaterialDesignOutlinedPasswordBoxEnabledComboBox�� 5Y      �� 5Z   "   $ 
Horizontal=�6-   $��-2,0,0,0q�6F   .+�5[   &     $ Password=�6>   �� 5\   &   $��Mot de passe��60   5]   #   5_      5a      �� 5b      -   5        $��bt_mp��5b   2   $
 Hand��6?   .��5c        $
 Edit=�62   5d      5e      5f      5g      5h      5i      