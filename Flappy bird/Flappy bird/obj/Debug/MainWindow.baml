   M S B A M L   `   `   `  ����F  BFlappy bird, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Flappy_birdFlappy_bird  5   	       Flappy_bird.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Flappy_bird     5   	     � Title$  Flappy bird��5   	   $	��490��6   $	��525��6*   .��5	      �� -   5        $��MyCanvas��5	      |�. 
�������.+�5   
   �� $	��145��6   $	��200��6   $��Images/clouds.png��6)   
 �� Top$ 74��6D   
 � Tag$ cloud��6T    �� Left$ 10��6`   �� 5   
   $	��145��6   $	��200��6   $��Images/clouds2.png��6)   $	 122��6E   $ cloud��6V   $	 301��6b   �� 5   
   $	��390��6   $��66��6   $��Images/pipeBottom.png��6(   $
 Obs1��6G   $	 217��6R   $ 71��6c   �� 5   
   $	��390��6   $��66��6   $��Images/pipeTop.png��6(   $
 Obs1��6D   $
 -316��6O   $ 71��6a   �� 5   
   $	��390��6   $��66��6   $��Images/pipeBottom.png��6(   $
 Obs2��6G   $	 267��6R   $	 415��6c   �� 5   
   $	��390��6   $��66��6   $��Images/pipeTop.png��6(   $
 Obs2��6D   $
 -283��6O   $	 415��6a   �� 5   
   $	��390��6   $��66��6   $��Images/pipeBottom.png��6(   $
 Obs3��6G   $	 306��6R   $	 235��6c   �� 5   
   $	��390��6   $��66��6   $��Images/pipeTop.png��6(   $
 Obs3��6D   $
 -252��6O   $	 235��6a   �� 5   
   -   5        $��
flappyBird��5      $��36��6"   $��50��6.   $��Images/flappyBird.png��69   $
��Fill=�6X   $ 34��6g   $	 190��6y   �� 5   
   -   5        $��txtScore��5      $��22(�6    $��	ExtraBold"�6.   $��Score:0��6E   5      5      