namespace CustomerService.Common.Messages.Email_Messages
{
    public static class EmailMessages
    {
        public static readonly string OtpSubjectTemplate = "Your Smile Store One-Time Password (OTP)";

        public static readonly string OtpBodyTemplate = @"
Hi {0},

You recently requested a one-time password (OTP) for Smile Login. Your OTP is:

**{1}**

Please note: This OTP will expire in 1 minute. For your security, please do not share this code with anyone.

If you did not request an OTP, please disregard this email.

If you encounter any difficulties, please don't hesitate to contact our support team at admin@smile.com.

Thanks,

The Smile Team";

        public static string GetOtpMessage(string customerName, string otpCode)
        {
            string formattedBody = string.Format(OtpBodyTemplate, customerName, otpCode);
            return formattedBody;
        }
    }
}
