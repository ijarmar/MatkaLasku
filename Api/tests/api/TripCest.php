<?php 

class TripCest
{
    private $companyId;
    private $tripId;

    public function _before(ApiTester $I)
    {
        $I->haveHttpHeader('Content-Type', 'application/json');
        $I->sendPost('/Companies', [
            'name' => 'Sovelluskontti'
        ]);
        $I->seeResponseCodeIs(\Codeception\Util\HttpCode::CREATED);
        $res = $I->grabResponse();
        $this->companyId = json_decode($res, true)['id'];
    }

    // tests
    public function addTripViaAPI(\ApiTester $I)
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
            'description' => 'moi',
            'passengerCount' => 1
        ]);
        $I->seeResponseCodeIs(\Codeception\Util\HttpCode::CREATED);
        $I->seeResponseIsJson();
        $I->seeResponseContainsJson([
            'companyId' => $this->companyId,
            'recipient' => 'John Doe',
            'purpose' => 'Work Trip',
            'distanceInKM' => 100,
            'locationDeparture' => 'Hämeenlinna',
            'locationDestination' => 'Helsinki',
            'description' => 'moi',
            'passengerCount' => 1
        ]);
        $res = $I->grabResponse();
        $this->tripId = json_decode($res, true)['id'];
    }

    public function getTripViaAPI(\ApiTester $I)
    {
        $I->sendGet("/Trips/$this->tripId");
        $I->seeResponseCodeIs(\Codeception\Util\HttpCode::OK);
        $I->seeResponseIsJson();
        $I->seeResponseContainsJson(['id' => $this->tripId]);
    }

    public function deleteTripViaAPI(\ApiTester $I)
    {
        $I->sendDELETE("/Trips/$this->tripId");
        $I->seeResponseCodeIs(\Codeception\Util\HttpCode::OK);
        $I->seeResponseIsJson();
        $I->seeResponseContainsJson(['id' => $this->tripId]);
    }
}
