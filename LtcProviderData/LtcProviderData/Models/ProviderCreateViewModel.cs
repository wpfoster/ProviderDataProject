using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LtcProviderData.Models
{
    public class ProviderCreateViewModel
    {
        //CMS Certification Number
        [Required]
        public int CCN { get; set; }
        
        //Bed Count
        public int BED_CNT { get; set; }

        //Facility Name
        public string FAC_NAME { get; set; }

        //Address: Street
        public string ST_ADR { get; set; }

        //Address: City
        public string CITY_NAME { get; set; }

        //Address: ZIP Code
        public string ZIP_CD { get; set; }

        //State Abbreviation
        public string STATE_CD { get; set; }

        //Telephone Number
        public string PHNE_NUM { get; set; }

        //Fax Phone Number
        public string FAX_PHNE_NUM { get; set; }

        //Eligibility Indicator
        public string ELGBLTY_SW { get; set; }

        //Compliance: Status
        public string CMPLNC_STUS_CD { get; set; }

        //Original Participation Date
        public string ORGNL_PRTCPTN_DT { get; set; }

        //Certification Date
        public string CRTFCTN_DT { get; set; }

        //Termination or Expiration Date                    
        public string TRMNTN_EXPRTN_DT { get; set; }

        //Termination Code
        public string PGM_TRMNTN_CD { get; set; }

        //Accreditation Type Code
        public string ACRDTN_TYPE_CD { get; set; }

        //Accreditation Effective Date
        public string ACRDTN_EFCTV_DT { get; set; }

        //Accreditation Expiration Date
        public string ACRDTN_EXPRTN_DT { get; set; }

        //Medicare Administrative Contractor (MAC) or Intermediary or Carrier Code
        public string INTRMDRY_CARR_CD { get; set; }

        //user generated comment
        public string Comment { get; set; }

    }
}