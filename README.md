How to run:
    Extract the zip file and with the terminal in the extracted folder run:
    dotnet run

Calculated results for test cases:
    Input: productId: PROD-001, quantity: 55, country: MK
    Your calculated finalPrice: 700.920000

    Input: productId: PROD-001, quantity: 100, country: DE
    Your calculated finalPrice: 1224.000000
    
    Input: productId: PROD-001, quantity: 25, country: USA
    Your calculated finalPrice: 330.0000

Bugs fixed:
    The discount should be applied if subtotal >= 500
    The tax should be calculated on subtotal - discountAmount
        taxAmount = (subtotal - discountAmount) * taxRate;