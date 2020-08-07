<?php 

class InvoiceCest
{
    private $companyId;
    private $tripId;

    public function _before(ApiTester $I)
    {
        $I->haveHttpHeader('Content-Type', 'application/json');
        
        $I->sendPost('/Companies', ['name' => 'Sovelluskontti']);
        $this->companyId = json_decode($I->grabResponse(), true)['id'];

        $I->sendPOST('/Trips', [
            'companyId' => $this->companyId,
            'departure' => date_format(new DateTime('5 Aug 2020 11:00:00'), 'c'),
            'recurrence' => date_format(new DateTime('5 Aug 2020 12:00:00'), 'c'),
            'recipient' => 'John Doe',
            'purpose' => 'Work Trip',
            'distanceInKM' => 100,
            'locationDeparture' => 'Hämeenlinna',
            'locationDestination' => 'Helsinki',
            'description' => 'moi',
            'passengerCount' => 1
        ]);
        $this->tripId = json_decode($I->grabResponse(), true)['id'];
    }

    // tests
    public function getInvoiceByTripId(\ApiTester $I)
    {
        $I->sendGET("/Invoices/$this->tripId");
        $I->seeResponseCodeIs(\Codeception\Util\HttpCode::OK);
        $I->seeResponseIsJson();
    }

    /**
     * @example { "km": 100, "passengerCount": 1, "kmAllowanceUnit": 0.46 }
     */
    public function InvoiceKMAllowanceUnitIsCorrect(\ApiTester $I, \Codeception\Example $example)
    {
        $I->sendGET("/Invoices/$this->tripId");
        $I->seeResponseCodeIs(\Codeception\Util\HttpCode::OK);
        $I->seeResponseIsJson();
        $I->seeResponseContainsJson([
            'distanceInKM' => $example['km'],
            'passengerCount' => $example['passengerCount'],
            'kmAllowanceUnit' => $example['kmAllowanceUnit']
        ]);
    }
}
