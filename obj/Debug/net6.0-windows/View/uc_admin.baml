   M S B A M L   `   `   `  ����V  RSouliereTrehou_parisSportif, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:SouliereTrehou_parisSportif.View SouliereTrehou_parisSportif.View  5      /    )SouliereTrehou_parisSportif.View.uc_admin   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:SouliereTrehou_parisSportif.View     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	         MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � .+�5   
   #  MaterialDesignThemes.Wpf.Card  .��5      �� -   5        $��
tabControl��5   �   $	��Top=�6   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ 
PrimaryMid=�68    * &MaterialDesignNavigationRailTabControl#��[ 6i   .@�5      �� ��5      �� 5      $
��auto��6%   $
��auto��62   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon    navigationRail-icon#��[ 66      Kind$
 Edit=�6c   �� 5      $��Center=�6(   $��
Edit users��6E   5      .��5      �� � 5       � ColumnDefinitions 5      �� 5   "   $
��Auto �63   �� 5    "   $��* �63   .+�5"      &   System.Windows.Controls.DataGrid  -   5        $��DG_listUsers��5"   �   $��0��6'      AutoGenerateColumns$ False��67      CanUserAddRows$ False��6S      SelectionUnit$
 Cell=�6j      SelectionMode$ Extended=�6   ��6�   �� *	ListUsers+	   Columns	 5#   "   0  *System.Windows.Controls.DataGridTextColumn  5$   &   ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��69      
IsReadOnly$
 True��6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *id+6\     5%   &   $
 Username��69   $
 True��6d    6K   �� *name+6d     5&   &   $
 Email��69   $
 True��6b    6H   �� *email+6b     5'   &   $
 
Permission��69   $
 True��6l    6M   �� *
permission+6l     5(   &   $
 Balance��69   $
 True��6z    6J   �� *	balance+ �� StringFormat$ $ {0}��6z   4	  .System.Windows.Controls.DataGridTemplateColumn	  5)   &   $

 Edit��6=   $
 True��6K    	  CellTemplate 5*   *   �� 5+   .   .R�5,   2   �� -   5        .��5-   5     $
 Edit=�6M   5.   3   5/   /   51   '   	  52   &   $
 	Supprimer��6=   $
 True��6P    53   *   �� 54   .   .R�55   2   �� -   5        .��56   5     $ Delete=�6M   57   3   58   /   5:   '   5<      �� 5=      -   5        $��
SP_addUser��5=   E   $��1��6)   $��15q�69   .+�5>   "   �� -   5        $��	LB_editId��5>   r     MaterialDesignLabel#��[ 6(   $��Center=�6U   .��6�   Id Utilisateur6�   �� 5?   "   -   5        $��TB_editUsername��5?   *   $��Center=�6A   $��10q�6\   .
  (MaterialDesignThemes.Wpf.TextFieldAssist 
  HasClearButton$
 True��6h    ! MaterialDesignOutlinedTextBox#��[ 6�   .��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint 6�   �� 5@   *    �� Orientation$ 
Horizontal=�65   $��-2,0,0,0q�6N   .+�5A   .     $
 User=�6F   �� 5B   .   $��Identifiant��68   5C   +   .��5D   F   5E   #   �� 5F   "   -   5        $��TB_editEmail��5F   *   $��Center=�6>   $��10q�6Y   $
 True��6e   #��[ 6�   .��6�    5G   &   �� 5H   *   $ 
Horizontal=�65   $��-2,0,0,0q�6N   .+�5I   .     $ Email=�6F   �� 5J   .   $��Email��68   5K   +   .��5L   F   5M   #   �� 5N   "   -	   5        $��TB_editBalance��5N   *   $��Center=�6@   $��10q�6[   $
 True��6g   #��[ 6�   .��6�    5O   &   �� 5P   *   $ 
Horizontal=�65   $��-2,0,0,0q�6N   .+�5Q   .     $ AccountBalance=�6F   �� 5R   .   $��Balance��68   5S   +   .��5T   F   5U   #   �� 5V   "   -
   5        $��CB_editPerm��5V   +    " MaterialDesignOutlinedComboBox#��[ 6>   $��10q�6v   $ 
Permission��6�      
HelperText$ 
Permission��6�   .@�5W   &   �� $
��User��63   �� 5X   &   $��Admin��63   5Y   #   �� 5Z   "   .+�5[   $   �� -   5         ��Name$6 0MaterialDesignOutlinedPasswordBoxEnabledComboBox��5[   -   $��Changer le mot de passe��6g   $��10q�6�   G� 5\   $   -   5        $��PB_editPassword��5^   0    + 'MaterialDesignOutlinedRevealPasswordBox#��[ 5\   0   $��10q�5]   0   $	��Top=�5_   0   $
 True��5`   0   {�5a   0   ��  �� Path$ 	IsChecked� �� ElementName$6 0MaterialDesignOutlinedPasswordBoxEnabledComboBox�� 5b   L   �� 5c   *   $ 
Horizontal=�65   $��-2,0,0,0q�6N   .+�5d   .     $ Password=�6F   �� 5e   .   $��Mot de passe��68   5f   +   5h   %   5i   #   �� 5j   "   -   5         	 MaterialDesignRaisedButton#��[	 5j   @   $��10q�6t   .��6�   
Modifier6�   5k      5l      5m      5n      �� 5o      ��5p      �� 5q      $
��auto��6%   $
��auto��62   .+�5r        #��[ 66   $	 Add=�6c   �� 5s      $��Center=�6(   $��	Add users��6E   5t      .��5v      �� �� 5w      .+�5x      �� -   5        $��TB_username��5x   &   $��Center=�5y   &   $��10q�5z   &   $
 True��5{   &   #��[ 5|   &   .��6]    5}   "   �� 5~   &   $ 
Horizontal=�61   $��-2,0,0,0q�6J   .+�5   *     $
 User=�6B   �� 5�   *   $��Identifiant��64   5�   '   .��5�   B   5�      �� 5�      -   5        $��TB_email��5�   &   $��Center=�5�   &   $��10q�5�   &   $
 True��5�   &   #��[ 5�   &   .��6]    5�   #   �� 5�   &   $ 
Horizontal=�61   $��-2,0,0,0q�6J   .+�5�   *     $ Email=�6B   �� 5�   *   $��Email��64   5�   '   .��5�   B   5�      �� 5�      -   5        $��CB_Perm��5�   '   #��[ 5�   '   $��10q�5�   '   $ 
Permission��5�   '   $ 
Permission��5�   '   .@�5�       �� $
��User��6-   �� 5�       $��Admin��6-   5�      G� 5�      -   5        $��PB_password��5�   *   #��[ 5�   *   $��10q�5�   *   $
 True��5�   *    5�   "   �� 5�   &   $ 
Horizontal=�61   $��-2,0,0,0q�6J   .+�5�   *     $ Password=�6B   �� 5�   *   $��Mot de passe��64   5�   '   5�      �� 5�      -   5        #��[	 5�   5   $��10q�6i   .��6u   	Ajouter6~   5�      5�      5�      �� 5�      $
{�True��6   ��5�      �� 5�      $
��auto��6%   $
��auto��62   .+�5�        #��[ 66   $ Settings=�6c   �� 5�      $��Center=�6(   $��Settings��6E   5�      .��5�      �� $��Center=�6    �� 5�      $
��2000��6$   � 5�       � RowDefinitions 5�   "   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5�   &   $��* �64   .+�5�   "   � $��1��6'   .+�5�   &   �� $/��)(update after restarting the application)��6,   $��Center=�6`   5�   #   � 5�   "   $��0��6'   .+�5�   &   �� $4��.Number of days for the appearance of the match��6,   $��Center=�6e   5�   #   � 5�   "   $��2��6'   .+�5�   &   �� $ 
Horizontal=�61   $��4q�6J   $��0��6U   .+�5�   *   	� -   5        $��	btn_day_1��5�   �     
 MaterialDesignTabRadioButton#��[
 66   $��4q�6l    d� 	IsChecked$ FalseY�6w   .��5�   .   �� .+�5�   2     $��Center=�6J   $	 One=�6g   �� 5�   2   $��0 4 0 0q�6<   $��FIRST��6M   5�   /   5�   +   	� 5�   *   -   5        $��	btn_day_2��5�   �   #��[
 66   $��4q�6l   $ FalseY�6w   .��5�   .   �� .+�5�   2     $��Center=�6J   $	 Two=�6g   �� 5�   2   $��0 4 0 0q�6<   $��SECOND��6M   5�   /   5�   +   	� 5�   *   -   5        $��	btn_day_3��5�   �   #��[
 66   $��4q�6l   $ FalseY�6w   .��5�   .   �� .+�5�   2     $��Center=�6J   $ Three=�6g   �� 5�   2   $��0 4 0 0q�6<   $��THIRD��6M   5�   /   5�   +   	� 5�   *   -   5        $��	btn_day_4��5�   �   #��[
 66   $��4q�6l   $ FalseY�6w   .��5�   .   �� .+�5�   2     $��Center=�6J   $
 Four=�6g   �� 5�   2   $��0 4 0 0q�6<   $��FOURTH��6M   5�   /   5�   +   	� 5�   *   -   5        $��	btn_day_5��5�   �   #��[
 66   $��4q�6l   $ FalseY�6w   .��5�   .   �� .+�5�   2     $��Center=�6J   $
 Five=�6g   �� 5�   2   $��0 4 0 0q�6<   $��FIFTH��6M   5�   /   5�   +   5�   '   5�   #   � 5�   "   $��3��6'   .+�5�   &   �� $��bookmaker chosen��6,   $��Center=�6G   5�   #   � 5�   "   $��4��6'   .+�5�   &   �� -   5        $��Cb_bookmakers��5�   /   #��[ 6u   $ 	bookmaker��6�   $	��256��6�   .@�5�   *   �� $��0��67   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      