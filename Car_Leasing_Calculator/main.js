document.addEventListener('DOMContentLoaded', () => {

    const carType = document.getElementById('carType');

    const leasePeriod = document.getElementById('leasePeriod');
    
    const carValue = document.getElementById('carValue');
    const carValueRange = document.getElementById('carValueRange');

    const downPayment = document.getElementById('downPayment');
    const downPaymentRange = document.getElementById('downPaymentRange');

    const totalLeasingCost = document.getElementById('totalLeasingCost');

    const downPaymentAmount = document.getElementById('downPaymentAmount');
    
    const monthlyInstalment = document.getElementById('monthlyInstalment');

    const interestRate = document.getElementById('interestRate');

    const carValueError = document.getElementById('carValueError');
    const downPaymentError = document.getElementById('downPaymentError');

    //usaglasuje range input i text input
    function synchronizeInputs() {
        carValueRange.value = carValue.value;
        downPaymentRange.value = downPayment.value;
    }

    //ne dozvoljava da unos bude veci od maksimalnog
    carValue.addEventListener('input', () => {
        if (parseInt(carValue.value) > 200000) {
            carValue.value = 200000;
        }
        carValueRange.value = carValue.value;
        validateInputs();
        calculateLease();
    });

    carValueRange.addEventListener('input', () => {
        carValue.value = carValueRange.value;
        validateInputs();
        calculateLease();
    });

    //ne dozvoljava da unos bude veci od dosvoljenog maksimuma
    downPayment.addEventListener('input', () => {
        if (parseInt(downPayment.value) > 50) {
            downPayment.value = 50;
        }
        downPaymentRange.value = downPayment.value;
        validateInputs();
        calculateLease();
    });

    downPaymentRange.addEventListener('input', () => {
        downPayment.value = downPaymentRange.value;
        validateInputs();
        calculateLease();
    });

    carType.addEventListener('change', () => {
        calculateLease();
    });

    leasePeriod.addEventListener('change', () => {
        calculateLease();
    });

    //validira unos, ukoliko je unos manji od dozvoljenog minimuma, prikazuje error poruke
    function validateInputs() {
        let isValid = true;

        if (parseInt(carValue.value) < 10000) {
            carValueError.textContent = "Car value must be at least €10,000.";
            isValid = false;
        } else {
            carValueError.textContent = "";
        }

        if (parseInt(downPayment.value) < 10) {
            downPaymentError.textContent = "Down payment must be at least 10%.";
            isValid = false;
        } else {
            downPaymentError.textContent = "";
        }

        return isValid;
    }



    function calculateLease() {
        if (!validateInputs()) {
            totalLeasingCost.textContent = "";
            downPaymentAmount.textContent = "";
            monthlyInstalment.textContent = "";
            interestRate.textContent = "";
            return;
        }

        const selectedCarType = carType.value;
        const selectedLeasePeriod = parseInt(leasePeriod.value);
        const selectedCarValue = parseInt(carValue.value);
        const selectedDownPaymentPercentage = parseInt(downPayment.value);

        //mora da bude selektovano ili brand new ili used inace ne racuna
        if (!selectedCarType) {
            interestRate.textContent = "";
            return;
        }

        //vec je setovano na pocetne vrednosti
        if (isNaN(selectedLeasePeriod) || isNaN(selectedCarValue) || isNaN(selectedDownPaymentPercentage)) {
            return;
        }


        const downPaymentAmountValue = (selectedDownPaymentPercentage / 100) * selectedCarValue;
        const principalAmount = selectedCarValue - downPaymentAmountValue;
        const annualInterestRate = (selectedCarType === 'new') ? 0.0299 : 0.037;
        const monthlyInterestRate = annualInterestRate / 12;
        const numPayments = selectedLeasePeriod;

        const monthlyPayment = (principalAmount * monthlyInterestRate * Math.pow(1 + monthlyInterestRate, numPayments)) /
            (Math.pow(1 + monthlyInterestRate, numPayments) - 1);

        const totalCost = (monthlyPayment * numPayments) + downPaymentAmountValue;

        totalLeasingCost.textContent = totalCost.toFixed(2) +"€";
        downPaymentAmount.textContent = downPaymentAmountValue.toFixed(2)+"€";
        monthlyInstalment.textContent = monthlyPayment.toFixed(2) +"€";
        interestRate.textContent = (annualInterestRate * 100).toFixed(2) + '%';
    }

    synchronizeInputs();
    calculateLease();
});
