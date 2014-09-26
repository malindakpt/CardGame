//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Card_Game
//{
//    class Round
//    {
   
// String winner_pos=null;
// //$gameC='';
 
// // $con=mysqli_connect("mysql14.000webhost.com","a6673651_malinda","78ui&*UI","a6673651_dbcards");
// // $game_id=$_POST[game_id];

//private String get_winner(String gameC,String nowC,String pos0,String pos1,String pos2,String pos3)
//{
//  // echo "nowC=$nowC--";	
//    String max1,max2;
//    String winner_pos0,winner_pos1;
//    if (getScoreCard(gameC,nowC,pos0)>getScoreCard(gameC,nowC,pos1)){
//      max1=pos0;
//       winner_pos0="0";
//    }
//    else{
//      max1=pos1;
//       winner_pos0="1";
//    }	  
//      //echo "max1=$max1--";	  
//    if (getScoreCard(gameC,nowC,pos2)>getScoreCard(gameC,nowC,pos3)){
//      max2=pos2;
//      winner_pos1="2";
//    }
//     else{
//      max2=pos3;
//       winner_pos1="3";
//    }  
//      // echo "max2=$max2--";   
//    if (getScoreCard(gameC,nowC,max1)>getScoreCard(gameC,nowC,max2)){ 
//     winner_pos=winner_pos0; 
//      return max1;
//    }
//    else { 
//      winner_pos=winner_pos1;
//      return max2;
//    }
//}


//private int getScore(String card)
//{
//    //String val=substr($card,1,2);
//    String val=card.Substring(1,2);

//    switch (val)
//        {
//            case "SE":
//              return 10;
//              break;
//            case "EI":
//              return 11;
//              break;
//            case "NI":
//              return 20;
//              break;
//            case "TE":
//              return 8;
//              break;
//            case "JA":
//              return 30;
//              break;
//            case "QU":
//              return 3;
//              break;
//            case "KI":
//              return 5;
//              break;
//            case "AC":
//              return 10;
//              break;
					  
//            default:
//              return 0;
//        }
//}

//private int getScoreCard(String gameC,String nowC,String card)
//{
//    //$val=substr($card,1,2);
//    String val=card.Substring(1,2);
//    String sym_card=card.Substring(0,1);
//    String sym_now=nowC.Substring(0,1);
//    String sym_game=gameC.Substring(0,1);
	
//    if(sym_game.Equals(sym_card)){
//        return 100*getScore(card);
//    }else if(sym_now.Equals(sym_card)){
//        return 10*getScore(card);
//    }else{
//        return getScore(card);
//    }
//}
 
//private int get_points(String pos0,String pos1,String pos2,String pos3)
//{
//    int points=getScore(pos0)+getScore(pos1)+getScore(pos2)+getScore(pos3);
//    return points;
//}

//public void get_round()
//{



//if($row = mysqli_fetch_array($result))
//{
//    $pos0=$row[0]; 
//}
//if($row = mysqli_fetch_array($result))
//{
//    $pos1=$row[0]; 
//}
//if($row = mysqli_fetch_array($result))
//{
//    $pos2=$row[0]; 
//}
//if($row = mysqli_fetch_array($result))
//{
//    $pos3=$row[0]; 
//}
// /////////////solving trump open///////////////////
 
//      $result1 =mysqli_query($con,"SELECT trump,given_card from Game where game_id='".$game_id."' ORDER BY bid desc");
//      if($row = mysqli_fetch_array($result1))
//      {
//        $gameC=$row[0]; 
//        $trump_player_given=$row[1]; 
//      }
	  
//      $result =mysqli_query($con,"SELECT start_by from Game where game_id='".$game_id."'");
//      if($row = mysqli_fetch_array($result))
//      {						 
//        $start_by=$row[0];
//      }
 
//      $result2 =mysqli_query($con,"SELECT given_card from Game where game_id='".$game_id."' and position='".$start_by."'");
//      if($row = mysqli_fetch_array($result2))
//      {
//        $nowC=$row[0];   
//      }
	
//    $sym_game_trump=substr($gameC,0,1);	
	
//        $trump_open=false;
//        if($gameC!=null && $trump_player_given!=null)
//        {
//                    ////check trump player has given the trump card
//                    if($gameC==$trump_player_given)
//                    {
						
//                        $trump_open=true;
//                    }		
//                    else
//                    {
//                        $sym_game_trump=substr($gameC,0,1);			
//                        $result =mysqli_query($con,"SELECT count(game_id) from Game where game_id='".$game_id."' and given_card like '".$sym_game_trump."%'");			
//                        if($row = mysqli_fetch_array($result))
//                        {
						
//                            $count=$row[0]; 			 
//                            ////check other player has given trump cards
//                            if($count>0)
//                            {
//                                        $sym_first_card=substr($nowC,0,1);								
//                                        ////check first player put a trump card
//                                        if($sym_first_card==$sym_game_trump)
//                                        {
//                                            ////No matter
//                                        }
//                                        else
//                                        {
//                                            $trump_open=true;
//                                        }			 				
//                            }
//                        }
//                    }	
//        }	
 
//    $win='';
	
/////	if($trump_open==1){
////		echo "OPEN";
//        mysqli_query($con,"UPDATE Game SET open_trump='".$sym_game_trump."' WHERE game_id='".$game_id."'");	
//    }else
//    {
//        echo "CLOSE";
//    }
//    $win=get_winner($gameC,$nowC,$pos0,$pos1,$pos2,$pos3) ;	
//    /////////////////////////////////
//    $points=get_points($pos0,$pos1,$pos2,$pos3) ;
//    $result2 =mysqli_query($con,"SELECT points from Game where game_id='".$game_id."' and given_card='".$win."'");
	 
//    $past_points=0;
//    if($row2 = mysqli_fetch_array($result2))
//    {
//        $past_points=$row2[0]; 
//         //echo $past_points;
//    }
 
//    $newPoints=$points+$past_points;
//    mysqli_query($con,"UPDATE Game SET points='$newPoints' WHERE game_id='".$game_id."' and given_card='".$win."'");
//     mysqli_query($con,"UPDATE Game SET given_card='',start_by='".$winner_pos."',status='".$winner_pos."' WHERE game_id='".$game_id."'" );  
 
////echo  $winner_pos;
/////////////////////////////
// echo "#"  ;

//    }
//}
