   M S B A M L   `   `   `  ����  Management-Hotel9    3Management_Hotel.Views.Dialogs.AddEditPaymentDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Gestion des Paiements��5   	   $	��500��6'   $	��400��64    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �� $��20q�6   .+�5   
   �� $��Détails du paiement��6   $��20(�6/   $��0,0,0,20q�6=   �� 5	   
   $��Réservation��6   �� 5
   
   -   5         ��Name$ ReservationComboBox��5
       �� DisplayMemberPath$ Idreservation��5       �� SelectedValuePath$ Idreservation��5      $��0,5,0,10q�5      �� 5   
   $��Montant��6   �� 5   
   -   5         ��Name$ MontantTextBox��5      $��0,5,0,10q�6*   �� 5   
   $��Date du paiement��6   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DatePaiementPicker��5      $��0,5,0,10q�61   �� 5   
   $��Mode de paiement��6   �� 5   
   -   5        $ ModePaiementComboBox��5      $��0,5,0,20q�61   .@�5      �� $��Carte bancaire��6   �� 5      $��Espèces��6   �� 5      $��Virement��6   �� 5      $��Chèque��6   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   .+�5      �� -   5        $��Annuler��5      $	��100��6B   $��0,0,10,0q�6N   �� 5      -   5        $��Enregistrer��5      $	��100��6D   5       5!      5"      