   M S B A M L   `   `   `  ����V  RSouliereTrehou_parisSportif, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SouliereTrehou_parisSportifSouliereTrehou_parisSportif  5   	   ,    &SouliereTrehou_parisSportif.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:SouliereTrehou_parisSportif     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	     � WindowStartupLocation$  CenterScreen=�5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   $	��500��5   	   $	��350��6    � WindowStyle$
 None=�6"    � 
ResizeMode$ NoResize=�65    � Title$ Login��6K   .��5      � 
�������.+�5   
   �� $	��280��6   $	��Top=�6!   ��5      �� 5       �� 
StartPoint$ 0.5,0&�6&    �� EndPoint$ 0.5,1&�69   .��5      �  � Color$ 	#FF6395BF��6#   � 5      $ 	#FF8983BD��6#   	 � Offset$		 0.5Q�65   � 5      $ 	#FF594E9C��6#   $	 1Q�65   5      5      �� 5   
   $��Resource/Image/home.png��6     LogoHome#��[ 61   �� 5   
     RectangleFieldInput#��[ 6   
 J� Effect
 5       3  -System.Windows.Media.Effects.DropShadowEffect  5!         Color$ 	#FFBBBBBB��6#      	Direction$ 0Q�65      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6k   5#      � 5$   
   $	��240��6   $��Bottom=�6   $��35 80q�67   .+�5%      �� $��	Connexion��6     
TitleLogin#��[ 6)   �� 5&      $��Center=�6   $��15q�64   .+�5'      �� -   5        $��username��5'      $
��0 10q�6*   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Identifiant��68    % !MaterialDesignFloatingHintTextBox#��[ 6e   $��Champagne & Limousines)�6�   $��18(�6�   G� 5(      -   5        $��password��5(      $
��0 10q�6.   $ Mot de passe��6<    ) %MaterialDesignFloatingHintPasswordBox#��[ 6j   $��Champagne & Limousines)�6�   $��18(�6�   5)      5*      �� 5+   
   -   5        $	��150��5+   $   $��Center=�60   $��Bottom=�6M   $
��0 58q�6h   $��	Connexion��6v   5,      5-      