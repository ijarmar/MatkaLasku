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
	 * @example { "passengerCount": 1, "kmAllowanceUnit": 0.46 }
	 * @example { "passengerCount": 0, "kmAllowanceUnit": 0.43 }
	 * @example { "passengerCount": 10, "kmAllowanceUnit": 0.73 }
     */
    public function InvoiceKMAllowanceUnitIsCorrect(\ApiTester $I, \Codeception\Example $example)
    {
		$I->haveHttpHeader('Content-Type', 'application/json');
		$I->sendPost('/Trips', [
			'companyId' => $this->companyId,
			'departure' => date_format(new DateTime('5 Aug 2020 11:00:00'), 'c'),
			'recurrence' => date_format(new DateTime('5 Aug 2020 12:00:00'), 'c'),
			'recipient' => 'John Doe',
			'purpose' => 'Work Trip',
			'distanceInKM' => 100,
			'locationDeparture' => 'Hämeenlinna',
			'locationDestination' => 'Helsinki',
			'description' => 'moro',
			'passengerCount' => $example['passengerCount']
		]);

		$tripId = json_decode($I->grabResponse(), true)['id'];

		$I->sendGET("/Invoices/$tripId");
        $I->seeResponseCodeIs(\Codeception\Util\HttpCode::OK);
        $I->seeResponseIsJson();
        $I->seeResponseContainsJson([
            'passengerCount' => $example['passengerCount'],
            'kmAllowanceUnit' => $example['kmAllowanceUnit']
        ]);
	}

	/**
	 * @example { "km": 100, "count": 0, "total": 43.00 }
	 * @example { "km": 200, "count": 0, "total": 86.00 }
	 * @example { "km": 100, "count": 1, "total": 46.00 }
	 * @example { "km": 200, "count": 1, "total": 92.00 }
	 */
	public function InvoiceKMAllowanceTotalIsCorrect(\ApiTester $I, \Codeception\Example $example)
	{	
		$I->haveHttpHeader('Content-Type', 'application/json');
		$I->sendPost('/Trips', [
			'companyId' => $this->companyId,
			'departure' => date_format(new DateTime('5 Aug 2020 11:00:00'), 'c'),
			'recurrence' => date_format(new DateTime('5 Aug 2020 12:00:00'), 'c'),
			'recipient' => 'John Doe',
			'purpose' => 'Work Trip',
			'distanceInKM' => $example['km'],
			'locationDeparture' => 'Hämeenlinna',
			'locationDestination' => 'Helsinki',
			'description' => 'moro',
			'passengerCount' => $example['count']
		]);
		
		$tripId = json_decode($I->grabResponse(), true)['id'];

		$I->sendGET("/Invoices/$tripId");
		$I->seeResponseCodeIs(\Codeception\Util\HttpCode::OK);
		$I->seeResponseIsJson();
		$I->seeResponseContainsJson([
			'kmAllowanceTotal' => $example['total']
		]);
    }
 
    /**
     * @example { "d":"2020-08-05T11:00:00+02:00", "r":"2020-08-05T16:00:00+02:00", "total": 0.0 }
     * @example { "d":"2020-08-05T11:00:00+02:00", "r":"2020-08-05T18:00:00+02:00", "total": 20.0 }
     * @example { "d":"2020-08-05T11:00:00+02:00", "r":"2020-08-06T11:00:00+02:00", "total": 43.0 }
     * @example { "d":"2020-08-05T11:00:00+02:00", "r":"2020-08-06T13:00:00+02:00", "total": 63.0 }
     */
    public function InvoiceDayBenefitTotalIsCorrect(\ApiTester $I, \Codeception\Example $example)
    {
        $I->haveHttpHeader('Content-Type', 'application/json');
		$I->sendPost('/Trips', [
			'companyId' => $this->companyId,
			'departure' => $example['d'],
			'recurrence' => $example['r'],
			'recipient' => 'John Doe',
			'purpose' => 'Work Trip',
			'distanceInKM' => 100,
			'locationDeparture' => 'Hämeenlinna',
			'locationDestination' => 'Helsinki',
			'description' => 'asdf',
			'passengerCount' => 1
		]);
		
		$tripId = json_decode($I->grabResponse(), true)['id'];

        $I->sendGET("/Invoices/$tripId");
		$I->seeResponseCodeIs(\Codeception\Util\HttpCode::OK);
		$I->seeResponseIsJson();
		$I->seeResponseContainsJson([
			'totalDayBenefit' => $example['total']
		]);
    }
}
