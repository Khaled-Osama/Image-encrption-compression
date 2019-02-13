using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 this class makes left feedback shift register
     
 */

namespace ImageQuantization
{
    class LFSR
    {
        /*
         this funcion doing:
         - xor last bit in the seed with the bit that's in tap position .
         - remove last bit from the seed .
         - shift the seed one bit to the left and putting the result from the xor.
         
        Complexity ==> O(1)
         */
        private static void shift1Bit(ref Int64 seed, int tapPos, int length)
        {
            Byte tapBit = (Byte)((seed >> tapPos) & 1);
            Byte fBit = 0;

            if ((int)Math.Log(seed, 2) == length - 1)
            {
                fBit = 1;
            }
            /*
             when shifting to the left in case the last bit which we want to remove is one 
             so we must remove it but when is 0 nothing will change .
             */
            if(seed >= ( 1 << (length - 1) ) )
            {
                seed -= (1 << (length - 1));
            }
            seed <<= 1;
            seed += (tapBit ^ fBit);
        }
        /*
             this function calling shift1Bit 8 times  
             and edit the final seed
         */

        public static Byte nShift(ref Int64 seed, int tapPos, int length)
        {
            for(int i = 0; i < 8; i++)
            {
                shift1Bit(ref seed, tapPos, length);
            }
            return (Byte) seed;
        }

    }
}
