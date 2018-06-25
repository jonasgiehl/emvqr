﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace StandardizedQR.UnitTests
{
    [TestClass]
    public class MerchantPayloadUnitTests
    {
        [TestMethod]
        public void PayloadWithSpecificationSample()
        {
            var merchantPayload = new MerchantPayload
            {
                PayloadFormatIndicator = 1,
                PointOfInitializationMethod = 12,
                MerchantAccountInformation = new MerchantAccountInformationDictionary
                {
                    { 29, new MerchantAccountInformation
                        {
                            GlobalUniqueIdentifier = "D15600000000",
                            PaymentNetworkSpecific = new Dictionary<int, string>
                            {
                                { 5, "A93FO3230Q" }
                            }
                        }
                    },
                    { 31, new MerchantAccountInformation
                        {
                            GlobalUniqueIdentifier = "D15600000001",
                            PaymentNetworkSpecific = new Dictionary<int, string>
                            {
                                { 3, "12345678" }
                            }
                        }
                    }
                },
                MerchantCategoryCode = 4111,
                TransactionCurrency = Iso4217Currency.China.Value.NumericCode,
                TransactionAmount = 23.72m,
                CountyCode = Iso3166Countries.China,
                MerchantName = "BEST TRANSPORT",
                MerchantCity = "BEIJING",
                TipOrConvenienceIndicator = 1,
                MerchantInformation = new MerchantInfoLanguageTemplate
                {
                    LanguagePreference = "ZH",
                    MerchantNameAlternateLanguage = "最佳运输",
                    MerchantCityAlternateLanguage = "北京"
                },
                AdditionalData = new MerchantAdditionalData
                {
                    StoreLabel = "1234",
                    CustomerLabel = "***",
                    TerminalLabel = "A6008667",
                    AdditionalConsumerDataRequest = "ME"
                },
                UnreservedTemplate = new MerchantUnreservedDictionary
                {
                    {91, new MerchantUnreservedTemplate
                        {
                            GlobalUniqueIdentifier = "A011223344998877",
                            ContextSpecificData = new Dictionary<int, string>
                            {
                                {7, "12345678" }
                            }
                        }
                    }
                },
            };

            var payload = merchantPayload.GeneratePayload();
            Assert.AreEqual(
                expected: "00020101021229300012D156000000000510A93FO3230Q31280012D15600000001030812345678520441115802CN5914BEST TRANSPORT6007BEIJING64200002ZH0104最佳运输0202北京540523.7253031565502016233030412340603***0708A60086670902ME91320016A0112233449988770708123456786304A13A",
                actual: payload);
        }


    }
}
